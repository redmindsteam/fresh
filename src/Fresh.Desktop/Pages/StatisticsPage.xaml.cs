using Fresh.Service.Services.PageServices;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Collections.ObjectModel;
using System.Drawing;
=======
>>>>>>> 80a1fe0 (Update Cassa)
using System.Linq;
using System.Windows;
using System.Windows.Controls;


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

            SetDefaultDate("Daily");
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

        private void SetDefaultDate(string currentRadio)
        {
            SetDefaults("01/01/1990", currentRadio);
        }

        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datePickerDepends();
        }
        private void daily_radio_Checked(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            datePickerDepends();
=======
            SetDefaults(StatDataPicker.Text, "Daily");
>>>>>>> 80a1fe0 (Update Cassa)
        }
        private void monthly_radio_Checked(object sender, RoutedEventArgs e)
        {
            datePickerDepends();

        }

        private void yearly_radio_Checked(object sender, RoutedEventArgs e)
        {
            datePickerDepends();
        }
        private async void SetDefaults(string datetime, string status)
        {
            StatisticPage statisticPage = new StatisticPage();
            var stats = await statisticPage.GetByCurrentDate(status, datetime);
            List<StatsView> statsViews = new List<StatsView>();
            if (stats.Count == 0)
            {
                ProductsDgUi.Visibility = Visibility.Hidden;
                lblInfo.Visibility = Visibility.Visible;
                return;
            }
            else 
            {
                foreach (var st in stats) statsViews.Add(st.Value);
                ProductsDgUi.Visibility = Visibility.Visible;
                lblInfo.Visibility = Visibility.Hidden;
                if (status == "Yearly")
                    ProductsDgUi.ItemsSource = statsViews.OrderByDescending(x => int.Parse(x.Date));
                else
                    ProductsDgUi.ItemsSource = statsViews.OrderByDescending(x => x.DateToOrder);
            }
<<<<<<< HEAD
        }
        private void datePickerDepends()
        {
            if (daily_radio.IsChecked == true || monthly_radio.IsChecked == true || yearly_radio.IsChecked == true)
            {
                StatDataPicker.IsEnabled = true;
                try
                {
                    DateTime.Parse(StatDataPicker.Text);
                    if (daily_radio.IsChecked == true)
                        SetDefaults(StatDataPicker.Text, "Daily");
                    else if (monthly_radio.IsChecked == true)
                        SetDefaults(StatDataPicker.Text, "Monthly");
                    else
                        SetDefaults(StatDataPicker.Text, "Yearly");
                }
                catch
                {
                    StatDataPicker.Text = string.Empty;
                    if (daily_radio.IsChecked == true)
                        SetDefaultDate("Daily");
                    else if (monthly_radio.IsChecked == true)
                        SetDefaultDate("Monthly");
                    else
                        SetDefaultDate("Yearly");
                }
            }
            else StatDataPicker.IsEnabled = false;
        }
        private void daily_radio_Unchecked(object sender, RoutedEventArgs e)
        {
            datePickerDepends();
        }
        private void monthly_radio_Unchecked(object sender, RoutedEventArgs e)
        {
            datePickerDepends();
        }

        private void yearly_radio_Unchecked(object sender, RoutedEventArgs e)
        {
            datePickerDepends();
        }

        private void statDataPicker_Changed(object sender, SelectionChangedEventArgs e)
        {
            datePickerDepends();
=======

            if (status == "Yearly")
                ProductsDgUi.ItemsSource = statsViews.OrderByDescending(x => int.Parse(x.Date));
            else
                ProductsDgUi.ItemsSource = statsViews.OrderByDescending(x => x.DateToOrder);
>>>>>>> 80a1fe0 (Update Cassa)
        }
    }
}
