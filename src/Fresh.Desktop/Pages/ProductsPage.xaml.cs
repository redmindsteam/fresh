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
            List<ProductsView> CashierPages = await products.GetProductViews();
            ProductsDgUi.ItemsSource = CashierPages;
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
    }
}
