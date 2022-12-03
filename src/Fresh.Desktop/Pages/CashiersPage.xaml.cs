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
    /// Interaction logic for CashiersPage.xaml
    /// </summary>
    public partial class CashiersPage : Page
    {
        public CashiersPage()
        {
            InitializeComponent();
            Click();
        }

        private void rdAddUser_Click(object sender, RoutedEventArgs e)
        {
           
        }
        public async void Click()
        {
            CashierPage cashiers = new CashierPage();
            List<CashierView> CashierPages = await cashiers.GetCashierViews();
            ProductsDgUi.ItemsSource = CashierPages;
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {

        }
    }
}
