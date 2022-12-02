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
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        private void DailyRadioButton_Clicked(object sender, RoutedEventArgs e)
        {
            MonthYear.Visibility = Visibility.Visible;
        }
        private void DailyRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MonthYear.Visibility = Visibility.Collapsed;
        }
        private void MonthlyRadioButton_Clicked(object sender, RoutedEventArgs e)
        {
            Year.Visibility = Visibility.Visible;
        }
        private void MonthlyRadioButton_Umchecked(object sender, RoutedEventArgs e)
        {
            Year.Visibility = Visibility.Collapsed;
        }

    }
}
