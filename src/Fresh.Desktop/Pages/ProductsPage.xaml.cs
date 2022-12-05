using Fresh.Service.Services.PageServices;
using Fresh.Service.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fresh.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            Click();
        }
        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public async void Click()
        {
            ProductPage products = new ProductPage();
            List<ProductsView> productPages = await products.GetProductViews();
            ProductsDgUi.ItemsSource = productPages;
        }

        private void PopupBox_OnClosed(object sender, RoutedEventArgs e)
        {

        }

        private void PopupBox_OnOpened(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsDgUi_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ProductsView products = (ProductsView)ProductsDgUi.SelectedItem;
            ProductPage productPage = new ProductPage();
            var result = await productPage.DeleteProduct(products);
            if (result)
            {
                ProductPage products1 = new ProductPage();
                List<ProductsView> productPages = await products1.GetProductViews();
                ProductsDgUi.ItemsSource = productPages;
                MessageBox.Show("Cashier successfully deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("There was wrong with delete cashier", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
