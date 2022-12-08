using AForge.Video;
using AForge.Video.DirectShow;
using Aspose.BarCode.BarCodeRecognition;
using Fresh.Desktop.Pages;
using Fresh.Domain.Entities;
using Fresh.Service.Director;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
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
        public  ObservableCollection<CassaData> cassaDatas = new ObservableCollection<CassaData>();
        public IList<VievModelProductLetter> vievModelProductLetters = new List<VievModelProductLetter>();
        public double price { get; private set; } = 0;
        public string word { get; set; } = "";
        public int count { get; private set; } = 0;

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
            
            cassaDataGrid.ItemsSource = cassaDatas.OrderBy(p => p.Name);
            word = "";
            count = 0;
            txtText_Block();

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

        public event PropertyChangedEventHandler PropertyChanged;

        private async void n1_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "1", Money = $"{double.Parse(resault.Price) * 1}" });
            price +=  double.Parse(resault.Price) * 1;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n2_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "2", Money = $"{double.Parse(resault.Price) * 2}" });
            price += double.Parse(resault.Price) * 2;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n3_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "3", Money = $"{double.Parse(resault.Price) * 3}" });
            price += double.Parse(resault.Price) * 3;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n4_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "4", Money = $"{double.Parse(resault.Price) * 4}" });
            price += double.Parse(resault.Price) * 4;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n5_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "5", Money = $"{double.Parse(resault.Price) * 5}" });
            price += double.Parse(resault.Price) * 5;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n6_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "6", Money = $"{double.Parse(resault.Price) * 6}" });
            price += double.Parse(resault.Price) * 6;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n7_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "7", Money = $"{double.Parse(resault.Price) * 7}" });
            price += double.Parse(resault.Price) * 7;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n8_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "8", Money = $"{double.Parse(resault.Price) * 8}" });
            price += double.Parse(resault.Price) * 8;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n9_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "9", Money = $"{double.Parse(resault.Price) * 9}" });
            price += double.Parse(resault.Price) * 9;
            txtText_Block();
            DataGridRefresh();
        }
        private async void n0_click(object sender, RoutedEventArgs e)
        {
            var resault = (CassaData)cassaDataGrid.SelectedItem;
            cassaDatas.Remove(resault);
            cassaDatas.Add(new CassaData { Name = resault.Name, KgL = resault.KgL, Price = resault.Price, Thenumber = "0", Money = "0" });
            txtText_Block();
            DataGridRefresh();
        }

        private void txtText_Block()
        {
           
            txt_Block.Text = price.ToString();
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
                            if (count == 0 && s.Length > 1)
                            {
                                word = s;
                                count++;
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
                Product();
            }
        }

        public async Task Product()
        {
            DirectorProductService directorProductService = new DirectorProductService();
            var resault = await directorProductService.GetAllAsync();
            int counterProduct = 0;
            
            foreach (var product in resault)
            {
                if (product.BarcodeName != word)
                {
                    counterProduct += 1;
                }
            }
            if (counterProduct == resault.Count - 1)
            {
                foreach (var product in resault)
                {
                   
                    if (product.BarcodeName == word)
                    {
                        var res = DataGridCheck();
                        if (!res.Result)
                        {
                            cassaDatas.Add(new CassaData { Name = product.Name, KgL = product.Unit, Price = product.Price.ToString(), Thenumber = "1", Money = $"{product.Price * 1}" });
                            price += product.Price * 1;
                            DataGridRefresh();
                            return;
                        }
                        else if(res.Result)
                        {
                            DirectorProductService directorProduct = new DirectorProductService();
                            var r = await directorProduct.GetAllAsync();
                            MessageBox.Show($"{cassaDatas.Count}");
                            foreach (var ress in cassaDatas)
                            {
                                var solishtir = ress;
                                foreach (var resb in r)
                                {
                                    if (ress.Name == resb.Name)
                                    {      
                                        cassaDatas.Remove(solishtir);
                                        double k = (double.Parse(ress.Price) / double.Parse(ress.Thenumber)) + double.Parse(ress.Price);
                                        int i = int.Parse(ress.Thenumber) + 1;
                                        cassaDatas.Add(new CassaData { Name = ress.Name, KgL = ress.KgL, Price = ress.Price, Thenumber = i.ToString(), Money = k.ToString() });
                                        MessageBox.Show($"{cassaDatas.Count}");
                                        price += double.Parse(ress.Price) * (double.Parse(ress.Price) / double.Parse(ress.Thenumber));
                                        txtText_Block();
                                        DataGridRefresh();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(word);
                MessageBox.Show("Ro'yhatdan o'tmagan ");
            }
            DataGridRefresh();
        }

        private async Task<bool> DataGridCheck()
        {
            var a = new ObservableCollection<CassaData>();

            DirectorProductService directorProductService = new DirectorProductService();
            var resault = await directorProductService.GetAllAsync();
            
            foreach (var res in cassaDatas)
            {
                foreach (var resa in resault)
                {

                    if (resa.Name == res.Name)
                    {
                        
                        return true;
                    }
                }
            }
            return false;
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
            var item = (CassaData)cassaDataGrid.SelectedItem;
            
            
            foreach (var cassaData in cassaDatas)
            {
                if (item.Name == cassaData.Name)
                {
                    price -= double.Parse(cassaData.Money);
                }
            }
            cassaDatas.Remove(item);
            txtText_Block();
            DataGridRefresh();
        }

        private void Delete_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {

            ChecksDescription checksDescription = new ChecksDescription();
            checksDescription.ShowDialog();

            string checkDescription = "";
            double pric = 0;
            foreach (var view in vievModelProductLetters)
            {
                checkDescription += $"{view.Name}   {view.KgL}   {view.Total}   {view.Price}\n";
                pric += view.TotalPrice;
            }
            Check check = new Check();
            check.CheckDescription = $"{checkDescription}\n\n\n{check.TotalSum}\n\n\n{check.Date}";
            check.Date = DateTime.Now;
            check.UserId = 1;
            check.TotalSum = (float)price;
            MessageBox.Show($"{checkDescription}\n\n\n{check.TotalSum}\n\n\n{check.Date}\n\n");
            price = 0;
            cassaDatas.Clear();
            txt_Block.Text = null;
            //Check check = new Check();
            //string checkDescription = "";
            //double price = 0;
            //foreach (var view in vievModelProductLetters)
            //{
            //    checkDescription += $"{view.Name}   {view.KgL}   {view.Total}   {view.Price}\n";
            //    price += view.TotalPrice;
            //}
            //check.CheckDescription = $"{check.CheckDescription}\n\n\n{check.Id}\n\n\n{check.Date}";
            //check.Date = DateTime.Now;
            //check.UserId = 1;
            //check.TotalSum = (float)price;


        }
    }
}
