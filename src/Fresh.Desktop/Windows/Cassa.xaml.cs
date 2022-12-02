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
            ObservableCollection<CassaData> datas = new ObservableCollection<CassaData>();
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });
            datas.Add(new CassaData { Name = "Sariyog", KgL = " Kg", Price = "20 000", Thunumber = "2", Summa = "40 000" });

            cassaDataGrid.ItemsSource = datas;
        }

        

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        public class CassaData
        { 
            public string Name { get; set; }
            public string KgL { get; set; }
            public string Price { get; set; }
            public string Thunumber { get; set; }
            public string Summa { get; set; }
        }

        private void RadioButton_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
