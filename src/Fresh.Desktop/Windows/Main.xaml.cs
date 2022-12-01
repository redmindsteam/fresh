using Fresh.Desktop.Pages;
using System;
using System.Windows;

namespace Fresh.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }
        private void rdCashiers_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/CashiersPage.xaml", UriKind.RelativeOrAbsolute));

        }
        private void rdStatistics_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/StatisticsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdChecks_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/ChecksPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdProducts_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/ProductsPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdConsignmentLetters_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/ConsignmentLettersPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        
    }
}
