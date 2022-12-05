using Fresh.Domain.Entities;
using Fresh.Service.Services.PageServices;
using Fresh.Service.ViewModels;
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
            SetDefaults(DateTime.Now.AddMonths(-36).ToString("MM/dd/yyyy"),"Daily");
            StatDataPicker.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void daily_radio_Checked(object sender, RoutedEventArgs e)
        {
            SetDefaults(StatDataPicker.Text,"Daily");
        }
        private void monthly_radio_Checked(object sender, RoutedEventArgs e)
        {
            SetDefaults(StatDataPicker.Text, "Monthly");
        }

        private void yearly_radio_Checked(object sender, RoutedEventArgs e)
        {
            SetDefaults(StatDataPicker.Text, "Yearly");
        }
        private async void SetDefaults(string datetime,string status)
        {
            StatisticPage statisticPage = new StatisticPage();
            var stats = await statisticPage.GetByCurrentDate(status, datetime);
            List<StatsView> statsViews = new List<StatsView>();
            foreach (var st in stats)
            {
                statsViews.Add(st.Value);
            }
            if (statsViews.Count == 0)
            {
                MessageBox.Show("There aren't any data,Try to select another DateTime", "Lack of data", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
                
            if(status == "Yearly")
                ProductsDgUi.ItemsSource = statsViews.OrderByDescending(x => int.Parse(x.Date));
            else
                ProductsDgUi.ItemsSource = statsViews.OrderByDescending(x=>x.DateToOrder);
        }
    }
}
