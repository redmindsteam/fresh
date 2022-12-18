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
            Category_ComboBox();
        }

        private async void Category_ComboBox()
        {
            DirectorProductService directorCategoryService = new DirectorProductService();
            var resault = directorCategoryService.GetAllAsync();
            foreach (var item in await resault)
            {
                strings.Add(item.Name);

            }
            txtProduct.ItemsSource = strings;
        }

        private void GridRefresh()
        {
            DataGridCassaLetter.ItemsSource = cassaData;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{txtPrice.Text}");
            if (txtProduct.Text.Length > 0 && txtPrice.Text.Length > 0 && txtTotal.Text.Length > 0 && txtKgL.Text.Length > 0)
            {
                VievModelProductLetter vievModelProductLetter = new VievModelProductLetter();
                vievModelProductLetter.Name = txtProduct.Text;
                vievModelProductLetter.KgL = txtKgL.Text;
                vievModelProductLetter.Total = txtTotal.Text;
                vievModelProductLetter.Price = txtPrice.Text;
                vievModelProductLetter.TotalPrice = double.Parse(txtTotal.Text.ToString()) * double.Parse(txtPrice.Text.ToString());
                vievModelProductLetters.Add(vievModelProductLetter);

                cassaData.Add(new VievModelProductLetter { Name = txtProduct.Text, KgL = txtKgL.Text, Total = txtTotal.Text, Price = txtPrice.Text });
                GridRefresh();

                txtProduct.Text = null;
                txtKgL.Text = null;
                txtTotal.Text = null;
                txtPrice.Text = null;
            }
            else
            {
                MessageBox.Show("Ma'luot to'liq kiritilmagan");
            }
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

            if (cassaData.Count > 0)
            {
                string checkDescription = "";
                double price = 0;
                Product product = new Product();
                foreach (var view in vievModelProductLetters)
                {
                    double price2 = double.Parse(view.Price) * double.Parse(view.Total);
                    checkDescription += $"{view.Name}        {view.Total} {view.KgL}      {price2}\n";
                    product.Value = float.Parse(view.Total);
                    product.Name = view.Name;
                    products.Add(product);
                    price += price2;
                }


                DirectorProductService directorProductService = new DirectorProductService();
                var resa = directorProductService.UpdateProduct(products);

                Fresh.Domain.Entities.ProductLetter check = new Fresh.Domain.Entities.ProductLetter();
                check.ProductDescription = checkDescription;
                check.Date = DateTime.Now.ToString();
                check.UserId = 1;
                check.Price = (float)price;
                checkDescription += $"\nTime: {check.Date}\n\n Total Money: {price}\n\n Vendor: Alisher";

                MessageBox.Show($"{checkDescription}");
                EmpolyeeProductLetterService empolyeeProductLetterService = new EmpolyeeProductLetterService();
                empolyeeProductLetterService.CreateAsync(check);
                vievModelProductLetters.Clear();
                txtProduct.Text = null;
                txtKgL.Text = null;
                txtTotal.Text = null;
                txtPrice.Text = null;
                cassaData.Clear();
                GridRefresh();
            }
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

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
