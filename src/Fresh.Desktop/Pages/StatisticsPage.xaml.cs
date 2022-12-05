using Fresh.Domain.Entities;
using Fresh.Service.Services.PageServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
using static Fresh.Desktop.Windows.Cassa;

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
            SetDefaults(DateTime.Now.ToString("MM/dd/yyyy"));
        }
        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private async void daily_radio_Checked(object sender, RoutedEventArgs e)
        {
            SetDefaults(StatDataPicker.Text);
        }
        private async void monthly_radio_Checked(object sender, RoutedEventArgs e)
        {
            StatisticPage statisticPage = new StatisticPage();
            var stats = await statisticPage.GetByCurrentDate("Monthly", StatDataPicker.Text);
            ProductsDgUi.ItemsSource = stats;
        }

        private async void yearly_radio_Checked(object sender, RoutedEventArgs e)
        {
            StatisticPage statisticPage = new StatisticPage();
            var stats = await statisticPage.GetByCurrentDate("Yearly", StatDataPicker.Text);
            ProductsDgUi.ItemsSource = stats;
        }
        private async void SetDefaults(string datetime)
        {
            StatisticPage statisticPage = new StatisticPage();
            var stats = await statisticPage.GetByCurrentDate("Daily", datetime);
            ProductsDgUi.ItemsSource = stats;
        }
    }
}
