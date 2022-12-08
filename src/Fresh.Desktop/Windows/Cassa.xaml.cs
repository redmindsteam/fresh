using AForge.Video;
using AForge.Video.DirectShow;
using Aspose.BarCode.BarCodeRecognition;
using Fresh.Desktop.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using static Fresh.Desktop.Windows.Cassa;

namespace Fresh.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for Cassa.xaml
    /// </summary>
    public partial class Cassa : Window
    {
        public static ObservableCollection<CassaData> cassaDatas = new ObservableCollection<CassaData>();
        public double price { get; private set; } = 0;
        public string word { get; set; } = "";

        FilterInfoCollection fil;
        public ObservableCollection<FilterInfo> VideoDevices { get; set; }

        public FilterInfo CurrentDevice
        {
            get { return _currentDevice; }
            set { _currentDevice = value; this.OnPropertyChanged("CurrentDevice"); }
        }


        public Cassa()
        {
            InitializeComponent();
            this.DataContext = this;
            GetVideoDevices();
            this.Closing += MainWindow_Closing;
            Video();
        }
        
        public void Video()
        {
            StartCamera();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopCamera();
        }



        public async void DataGridRefresh()
        {
            cassaDataGrid.ItemsSource = cassaDatas;
            word = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CassaConsigmentLetter cassa = new CassaConsigmentLetter();
            cassa.Show();
        }

        public class CassaData
        { 
            public string Name { get; set; }
            public string KgL { get; set; }
            public string Price { get; set; }
            public string Thenumber { get; set; }
            public string Money { get; set; }
        }



        private async void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cassaDataGrid.Items != null)
            {
                cassaDataGrid.ItemsSource = null;
            }
        }

        private async void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            
           
            for (int i = 0; i < cassaDataGrid.Items.Count; i++)
            {
                price += 0;
            }
            
            MessageBox.Show($"{price}");
        }


        private async void DataGrid_Load(object sender, RoutedEventArgs e)
        {
            
            DataGridRefresh();
        }

        private async void btnDeletd_Click(object sender, RoutedEventArgs e)
        {
            var item = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(item);
            DataGridRefresh();
        }



        private async void n1_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "1" });
            DataGridRefresh();
        }
        private async void n2_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "2" });
            DataGridRefresh();
        }

        private async void n3_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "3" });
            DataGridRefresh();
        }

        private async void n4_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "4" });
            DataGridRefresh();
        }

        private async void n5_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "5" });
            DataGridRefresh();
        }

        private async void n6_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "6" });
            DataGridRefresh();
        }

        private async void n7_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "7" });
            DataGridRefresh();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private async void n8_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "8" });
            DataGridRefresh();
        }

        private async void n9_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "9" });
            DataGridRefresh();
        }

        private async void n0_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = resault.Thenumber, Money = "0" });
            DataGridRefresh();
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
                int count = 0;
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
                            if (count == 0)
                            {
                                word = s;
                                count++;
                            };
                          
                            return;
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
                CurrentDevice = VideoDevices[0];
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
                MessageBox.Show(word);
                cassaDatas.Add(new CassaData { Name = word, KgL = "Dona", Price = "20 000", Thenumber = "1", Money = "20 000" });
                DataGridRefresh();
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

        private void Window_Close(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {
            
        }

        private void cassaDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
