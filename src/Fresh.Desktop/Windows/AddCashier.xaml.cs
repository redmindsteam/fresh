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
using System.Windows.Shapes;

namespace Fresh.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for AddCashier.xaml
    /// </summary>
    public partial class AddCashier : Window
    {
        public AddCashier()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CashierView cashierView = new CashierView()
            {
                FullName=txtUser.Text,
                Email=txtEmail.Text,
                Password=txtPassword.Password,
                PhoneNumber=txtPhone.Text,
                PassportSeria=txtPassSeriya.Text,
            };
            CashierPage cashierPage = new CashierPage();
            var result = await cashierPage.AddCashier(cashierView);
            if (result)
            {
                MessageBox.Show("Cashier succesfully created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("There was wrong with adding cashier", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
