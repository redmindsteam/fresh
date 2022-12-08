using Fresh.Desktop.Windows;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.Services.PageServices;
using Fresh.Service.ViewModels;
using MaterialDesignThemes.Wpf;
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
        public static bool Check;
        public CashiersPage()
        {
            InitializeComponent();
            Click();
        }

       
        public async void Click()
        {
            CashierPage cashiers = new CashierPage();
            List<CashierView> CashierPages = await cashiers.GetCashierViews();
            ProductsDgUi.ItemsSource = CashierPages;
        }

        private async void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            CashierPage cashierPage = new();
            var user =(CashierView)ProductsDgUi.SelectedItem;
            if(user == null) 
            {
                MessageBox.Show("Please select row","Error",MessageBoxButton.OK,MessageBoxImage.Hand); return;
            }
            if(await cashierPage.UpdateCashier(user.Id,user))
                MessageBox.Show("Cashier successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("There was wrong with update cashier", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private async void btnDeleteUser(object sender, RoutedEventArgs e)
        {
            CashierView cashierView = (CashierView)ProductsDgUi.SelectedItem;
            CashierPage cashierPage = new CashierPage();
            var result = await cashierPage.DeleteCashier(cashierView);
            if (result)
            {
                CashierPage cashiers = new CashierPage();
                List<CashierView> CashierPages = await cashiers.GetCashierViews();
                ProductsDgUi.ItemsSource = CashierPages;
                MessageBox.Show("Cashier successfully deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("There was wrong with delete cashier", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private async void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (!Check)
            {
                AddCashier add = new AddCashier();
                add.Show();
                Check = true;
            }

        }

        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Click();
        }
    }
}
