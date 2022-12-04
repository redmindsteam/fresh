﻿using Fresh.Desktop.Pages;
using MaterialDesignThemes.Wpf;
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
            CassaChesk cassaChesk = new CassaChesk();
            cassaChesk.Show();
        }

        public class CassaData
        { 
            public string Name { get; set; }
            public string KgL { get; set; }
            public string Price { get; set; }
            public string Thenumber { get; set; }
            public string Money { get; set; }
        }
    }
}
