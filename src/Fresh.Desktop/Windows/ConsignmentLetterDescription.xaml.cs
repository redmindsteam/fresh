using Fresh.Desktop.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fresh.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for ConsignmentLetterDescription.xaml
    /// </summary>
    public partial class ConsignmentLetterDescription : Window
    {
        public ConsignmentLetterDescription()
        {
            InitializeComponent();
            SetValues();
        }

        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void SetValues()
        {
            ProductsDgUi.ItemsSource = ConsignmentLettersPage.consigmentLetterDetailsView;
        }
    }
}
