using Fresh.Domain.Entities;
using Fresh.Service.Services.PageServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            


        }

        private async void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(StatDataPicker.Text);
            StatisticPage statisticPage = new StatisticPage();
            var stats = await statisticPage.GetByCurrentDate(StatDataPicker.Text);
            ProductsDgUi.ItemsSource = stats;
        }

        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductsDgUi_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
