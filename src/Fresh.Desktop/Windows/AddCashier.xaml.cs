using Fresh.Desktop.Pages;
using Fresh.Domain.Entities;
using Fresh.Service.Services.PageServices;
using Fresh.Service.Tools;
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
            CashiersPage.Check = false;
        }
        //was Abdulaziz and Sanjar's work
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AddCashierPage addCashierPage = new AddCashierPage();
            var resalt = await addCashierPage.IsValidInputs(txtEmail.Text,txtPassword.Password, txtPassSeriya.Text, txtPhone.Text);
            if (resalt.result)
            {
                CashierView cashierView = new CashierView()
                {
                    FullName = txtName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Password,
                    PhoneNumber = (await ToolBox.IsPhoneNumber(txtPhone.Text)).number,
                    PassportSeria = txtPassSeriya.Text,
                };

                CashierPage cashierPage = new CashierPage();
                var result = await cashierPage.AddCashier(cashierView);
                if (result)
                {
                    CashiersPage.Check = false;
                    MessageBox.Show("Cashier succesfully created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    CashiersPage.Check = true;
                    MessageBox.Show($"Some infos are the same with already existed user,Please check again", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);

                }
            }
            else
            {
                MessageBox.Show($"{resalt.status}", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

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

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassSeriya_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
