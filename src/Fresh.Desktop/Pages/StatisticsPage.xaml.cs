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

namespace Fresh.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private bool rb1PrevState;
        private bool rb2PrevState;
        private bool rb3PrevState;
        public StatisticsPage()
        {
            InitializeComponent();
            rb1PrevState = this.daily_radio.IsChecked.Value;
            rb2PrevState = this.monthly_radio.IsChecked.Value;
            rb3PrevState = this.yearly_radio.IsChecked.Value;

            SetDefaultDate();
        }

        private void RBtn_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;

            if (rbtn != null)
            {
                if (rbtn.IsChecked.Value == true)
                {
                    switch (rbtn.Name)
                    {
                        case "daily_radio":
                            if (rb1PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb1PrevState = false;
                            }
                            else
                            {
                                rb1PrevState = true;
                                ResetRBPrevStates("daily_radio");
                            }
                            break;
                        case "monthly_radio":
                            if (rb2PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb2PrevState = false;
                            }
                            else
                            {
                                rb2PrevState = true;
                                ResetRBPrevStates("monthly_radio");
                            }
                            break;
                        case "yearly_radio":
                            if (rb3PrevState == true)
                            {
                                rbtn.IsChecked = false;
                                rb3PrevState = false;
                            }
                            else
                            {
                                rb3PrevState = true;
                                ResetRBPrevStates("yearly_radio");
                            }
                            break;
                        
                        default:
                            break;
                    }
                }
            }
        }

        private void ResetRBPrevStates(string _excludeRB)
        {
            rb1PrevState = (_excludeRB == "daily_radio" ? rb1PrevState : false);
            rb2PrevState = (_excludeRB == "monthly_radio" ? rb2PrevState : false);
            rb3PrevState = (_excludeRB == "yearly_radio" ? rb3PrevState : false);
        }

        private void SetDefaultDate()
        {
            SetDefaults(DateTime.Now.AddMonths(-36).ToString("MM/dd/yyyy"), "Daily");
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
