using Fresh.DataAccess.Repositories;
using Fresh.Service.Services.Empolyee;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Fresh.Desktop.Windows.Cassa;

namespace Fresh.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for CassaConsigmentLetter.xaml
    /// </summary>
    public partial class CassaConsigmentLetter : Window
    {
        public  IList<VievModelProductLetter> vievModelProductLetters = new List<VievModelProductLetter>();
      

        public CassaConsigmentLetter()
        {
            InitializeComponent();
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
