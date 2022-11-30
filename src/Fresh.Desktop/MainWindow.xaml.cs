using Fresh.Desktop.Windows;
using Fresh.Service.Attributes;
using Fresh.Service.Director;
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
            if (response.result)
            {
                if (CurrentUserSingelton.Instance.IsAdmin == 0)
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
            else
            {
                MessageBox.Show($"{response.error}", "Try again", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
            txtEmail.Clear();
            txtPassword.Clear();
        }
    }
}
