using Fresh.Desktop.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
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
        public Cassa()
        {
            InitializeComponent();
            refreshDataGridsss();
        }

        public void refreshDataGridsss()
        {
           
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Asal", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });

            
        }

        public async void DataGridRefresh()
        {
            cassaDataGrid.ItemsSource = cassaDatas;
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

        private async void WrapPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
    }
}
