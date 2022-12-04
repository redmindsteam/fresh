using Fresh.Desktop.Pages;
using System.Collections.ObjectModel;
using System.Windows;

namespace Fresh.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for Cassa.xaml
    /// </summary>
    public partial class Cassa : Window
    {
        public Cassa()
        {
            InitializeComponent();
            ObservableCollection<CassaData> cassaDatas = new ObservableCollection<CassaData>();
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
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });
            cassaDatas.Add(new CassaData { Name = "Kolbasa", KgL = "Kg", Price = "20.000", Thenumber = "2", Money = "40 000" });

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

        private void cassaDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cassaDataGrid.Items != null)
            {
                cassaDataGrid.ItemsSource = null;
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            double price = 0;   
            foreach (var cassaData in cassaDataGrid.Items)
            {
                price += double.Parse(ProductKgL.ToString()) * double.Parse(ProductPrice.ToString());
            }
            MessageBox.Show($"{price}");
        }
    }
}
