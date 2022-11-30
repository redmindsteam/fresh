using Fresh.Desktop.Windows;
using Fresh.Service.Attributes;
using Fresh.Service.Director;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fresh.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DirectorRegisterService service = new DirectorRegisterService();
            var response = await service.UserValidation(txtEmail.Text, txtPassword.Password);
            Errorlist.Content = response;
            Errorlist.Visibility = Visibility.Visible;
            EmailButton.Visibility = Visibility.Hidden;
            Errorlists.Visibility = Visibility.Hidden;
            if (response == string.Empty)
            {
                if (CurrentUserSingelton.Instance.IsAdmin == 1)
                {
                    Main main = new Main();
                    main.Show();
                    this.Close();
                }
                else
                {
                    Cassa cassa = new Cassa();
                    cassa.Show();
                    this.Close();
                }
            }
            else if(response == "Incorrect password")
            {
                EmailButton.Visibility=Visibility.Visible;
                Errorlists.Visibility=Visibility.Visible;
                txtEmail.Clear();
                txtPassword.Clear();
            }
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
            txtEmail.Clear();
            txtPassword.Clear();
        }
        //yondagi email button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Border1.Visibility = Visibility.Hidden;
            EmailSMS.Visibility = Visibility.Visible;
            LableCreate.Visibility=Visibility.Visible;
            UpdatePass.Visibility = Visibility.Visible;
            EmailButton.Visibility = Visibility.Hidden;
            LableCreate.Visibility = Visibility.Visible;
            CreateNew.Visibility=Visibility.Visible;
            CreateNew2.Visibility=Visibility.Visible;
            Cack_Password.Visibility = Visibility.Visible;
            UpdatePass.Visibility=Visibility.Visible;
            UpdatePass2.Visibility=Visibility.Visible;
            Errorlist.Visibility=Visibility.Hidden;
            Errorlists.Visibility = Visibility.Hidden;

        }
        //upddate button password
        private void Button_email(object sender, RoutedEventArgs e)
        {
            Border1.Visibility = Visibility.Visible;
            EmailSMS.Visibility = Visibility.Hidden;
            LableCreate.Visibility = Visibility.Hidden;
            UpdatePass.Visibility = Visibility.Hidden;
            LableCreate.Visibility = Visibility.Hidden;
            CreateNew.Visibility = Visibility.Hidden;
            CreateNew2.Visibility = Visibility.Hidden;
            Cack_Password.Visibility = Visibility.Hidden;
            UpdatePass.Visibility = Visibility.Hidden;
            UpdatePass2.Visibility = Visibility.Hidden;
            Errorlist.Visibility = Visibility.Hidden;
            Errorlists.Visibility = Visibility.Hidden;
            txtUpdate.Clear();
            txtUpdate2.Clear();
            txtChack.Clear();
        }

         //EmailAddressAttribute yoki Phone numberga smsm yuboraydigan textBox
        private void textChack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtChack.Focus();
        }

        private void txtChack_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtChack.Text) && txtChack.Text.Length > 0)
            {
                textChack.Visibility = Visibility.Collapsed;
              
            }
            else
            {
                textChack.Visibility = Visibility.Visible;
            }
        }
        //Password Update1 textBox
        private void txtUpdate_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUpdate.Password) && txtUpdate.Password.Length > 0)
            {
                textUpdate.Visibility = Visibility.Collapsed;
            }
            else
            {
              textUpdate.Visibility = Visibility.Visible;
            }
        }
        private void textUpdate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUpdate.Focus();

        }
        //Password Update2 textBox

        private void textUpdate2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUpdate2.Focus();
        }

        private void txtUpdate_TextChanged2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUpdate2.Password) && txtUpdate2.Password.Length > 0)
            {
                textUpdate2.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUpdate2.Visibility = Visibility.Visible;
            }
        }
    }
}
