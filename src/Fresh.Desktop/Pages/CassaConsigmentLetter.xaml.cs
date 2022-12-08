using AForge.Video.DirectShow;
using AForge.Video;
using Aspose.BarCode.BarCodeRecognition;
using Fresh.Service.Services.Empolyee;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static Fresh.Desktop.Windows.Cassa;
using Fresh.Desktop.Windows;
using Fresh.Service.Director;

namespace Fresh.Desktop.Pages
{
    public partial class CassaConsigmentLetter : Window
    {
        public  IList<VievModelProductLetter> vievModelProductLetters = new List<VievModelProductLetter>();
        ObservableCollection<string> strings = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public double price { get; private set; } = 0;
        public string word { get; private set; } = "";
        public int count { get; private set; } = 0;
        public bool StartStop = false;

        FilterInfoCollection fil;
        public ObservableCollection<FilterInfo> VideoDevices { get; set; }

        public FilterInfo CurrentDevice
        {
            get { return _currentDevice; }
            set { _currentDevice = value; this.OnPropertyChanged("CurrentDevice"); }
        }


        public CassaConsigmentLetter()
        {
            InitializeComponent();
            Category_ComboBox();
            this.DataContext = this;
            GetVideoDevices();
            this.Closing += MainWindow_Closing;
            Video();
        }

        private async void Category_ComboBox()
        {
            DirectorCategoryService directorCategoryService = new DirectorCategoryService();
            var resault = directorCategoryService.GetAllAsync();
            foreach (var item in await resault.Item1)
            { 
                strings.Add(item.Name);

            }
            txtCategory.ItemsSource = strings;
        }

        public void Video()
        {
            StartCamera();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopCamera();
        }


        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            VievModelProductLetter vievModelProductLetter = new VievModelProductLetter();
            vievModelProductLetter.Name = txtProduct.Text;
            vievModelProductLetter.KgL = txtKgL.Text;
            vievModelProductLetter.Total = txtTotal.Text;
            vievModelProductLetter.Price = txtPrice.Text;
            vievModelProductLetter.TotalPrice = double.Parse(txtTotal.Text.ToString()) * double.Parse(txtPrice.Text.ToString());
            vievModelProductLetters.Add(vievModelProductLetter);


            ObservableCollection<VievModelProductLetter> cassaDatas = new ObservableCollection<VievModelProductLetter>();
            cassaDatas.Add(new VievModelProductLetter { Name = txtPrice.Text, KgL = txtKgL.Text, Total = txtTotal.Text, Price = txtPrice.Text});
            DataGridCassaLetter.ItemsSource = cassaDatas;


            txtProduct.Text = null;
            txtKgL.Text = null;
            txtTotal.Text = null;
            txtPrice.Text = null;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            txtProduct.Text = null;
            txtKgL.Text = null;
            txtTotal.Text = null;
            txtPrice.Text = null;
        }

        private async void Close_Click(object sender, RoutedEventArgs e)
        {
            vievModelProductLetters.Clear();
            txtProduct.Text = null;
            txtKgL.Text = null;
            txtTotal.Text = null;
            txtPrice.Text = null;
            DataGridCassaLetter.ItemsSource = null;
            this.Close();
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            string checkDescription = "";
            double price = 0;
            foreach (var view in vievModelProductLetters)
            {
                checkDescription += $"{view.Name}   {view.KgL}   {view.Total}   {view.Price}\n";
                price += view.TotalPrice;
            }
            Fresh.Domain.Entities.ProductLetter check = new Fresh.Domain.Entities.ProductLetter();
            check.ProductDescription= checkDescription;
            check.Date = DateTime.Now.ToString();
            check.UserId = 1;
            check.Price = (float)price;

            MessageBox.Show($"{check.Price}");
            EmpolyeeProductLetterService empolyeeProductLetterService = new EmpolyeeProductLetterService();
            empolyeeProductLetterService.CreateAsync(check);
            vievModelProductLetters.Clear();
            txtProduct.Text = null;
            txtKgL.Text = null;
            txtTotal.Text = null;
            txtPrice.Text = null;
            DataGridCassaLetter.ItemsSource = null;
        }

        private async void NotAccept_Click(object sender, RoutedEventArgs e)
        {
            DataGridCassaLetter.ItemsSource = null;
            vievModelProductLetters.Clear();
            txtProduct.Text = null;
            txtKgL.Text = null;
            txtTotal.Text = null;
            txtPrice.Text = null;
        }

        private async void Grid_Load(object sender, RoutedEventArgs e)
        {
            fil = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in fil)
            {

            }
        }

        private IVideoSource _videoSource;
        private FilterInfo _currentDevice;



        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartCamera();
        }

        private async void video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                TimeOnly time = new();
                string s = "";

                BitmapImage bi;
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    bi = bitmap.ToBitmapImage();

                    using (BarCodeReader reader = new BarCodeReader(BitmapImage2Bitmap(bi), DecodeType.ISBN))
                    {
                        if (reader.ReadBarCodes().Length > 0 && time.Second + 1 < TimeOnly.FromDateTime(DateTime.Now).Second)
                        {
                            time = new();
                            BarCodeResult result = reader.ReadBarCodes()[0];
                            var res = result.CodeText.ToCharArray(0, 9);
                            foreach (char c in res)
                            {
                                s += c;
                            }
                            if (count == 0 && s.Length > 1)
                            {
                                word = s;
                                count++;
                                MessageBox.Show(s);
                                return;

                            };
                            if (count == 1)
                            {
                                return;
                            }
                        }
                    }
                }

                bi.Freeze();
                Dispatcher.BeginInvoke(new ThreadStart(delegate { videoPlayer.Source = bi; }));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error on _videoSource_NewFrame:\n" + exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StopCamera();
            }
        }

        public void StartStopFunc()
        {
            if (StartStop == true)
            {
                StopCamera();
            }
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {


            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }


        private async void GetVideoDevices()
        {
            VideoDevices = new ObservableCollection<FilterInfo>();
            foreach (FilterInfo filterInfo in new FilterInfoCollection(FilterCategory.VideoInputDevice))
            {
                VideoDevices.Add(filterInfo);
            }
            if (VideoDevices.Any())
            {
                CurrentDevice = VideoDevices[1];
            }
            else
            {
                MessageBox.Show("No video sources found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void StartCamera()
        {
            if (CurrentDevice != null)
            {
                _videoSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
                _videoSource.NewFrame += video_NewFrame;
                _videoSource.Start();
            }
        }

        private async void StopCamera()
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                cassaDatas.Add(new CassaData { Name = word, KgL = "Dona", Price = "20000", Thenumber = "1", Money = "20000" });
                
            }
        }


        protected async void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }



        private async void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopCamera();
        }

        private void DataGrid_Refresh(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Close(object sender, ContextMenuEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
        }

        private async void ComboBoxCategory_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
 
            
        }

        private async void txtProduct_Mouse_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (txtCategory.Text != null)
            {
                txtProduct.IsEnabled= false;
            }
            
            MessageBox.Show("txt");
        }
    }
}
