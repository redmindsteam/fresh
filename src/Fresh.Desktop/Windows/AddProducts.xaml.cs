using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Desktop.Pages;
using Fresh.Domain.Entities;
using Fresh.Service.Services.PageServices;
using System;
using System.Collections.Generic;
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
using ZXing;

namespace Fresh.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        public AddProducts()
        {
            InitializeComponent();
            func();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ProductsPage.chack = false;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {   
            if(DateTime.Parse(Productdate.Text) <= DateTime.Parse(Expiredate.Text))
            {
                float value;
                if(float.TryParse(Price.Text, out value))
                {
                    ICategoryRepository categoryRepository = new CategoryRepository();
                    Category category = await categoryRepository.GetByName(categoryname.Text);
                    Product product = new Product()
                    {
                        Name = ProductName.Text,
                        CategoryId = category.Id,
                        Price = float.Parse(Price.Text),
                        Unit = Unit.Text,
                        BarcodeName = BarCode.Text,
                        ProductionDate = Productdate.Text,
                        ExpireDate = Expiredate.Text,
                        Value = 0,
                    };
                    ProductPage productsPage = new ProductPage();
                    var result = await productsPage.AddProdact(product);
                    if (result)
                    {
                        ProductsPage.chack = false;
                        MessageBox.Show("Product succesfully created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There was wrong with adding product", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        ProductsPage.chack = true;
                    }
                }
                else
                {
                    MessageBox.Show("Enter the price only numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
            {
                MessageBox.Show("The Expire date before than Product data ", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        public async void func()
        {
            CategoriyesPage categoriyesPage = new CategoriyesPage();
            var raesalt = await categoriyesPage.GetCategories();
            foreach (var c in raesalt)
            {
                categoryname.Items.Add(c.Name);
            }
        }
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CategoriyesPage categoriyesPage = new CategoriyesPage();
            bool result = await categoriyesPage.AddCategories(categoryname.Text);
            if (result)
            {
                ProductsPage.chack = false;
                MessageBox.Show("Category succesfully created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("There was wrong with adding Category", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                ProductsPage.chack = true;
            }
        }

        private void Window_MouseDowns(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ProductName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void categoryname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
