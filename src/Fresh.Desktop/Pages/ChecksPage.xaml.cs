﻿using Dynamitey;
using Fresh.Domain.Entities;
using Fresh.Service.Director;
using Fresh.Service.Services.PageServices;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for ChecksPage.xaml
    /// </summary>
    public partial class ChecksPage : Page
    {
        public ChecksPage()
        {
            InitializeComponent();
            DataContext = this;
            Click();
            
        }

        private void comboBoxCashiers_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public async void Click()
        {
            CheckPage check = new CheckPage();
            List<ChecksView> ChecksPages = await check.GetChecksViews();
            DirectorRegisterService directorRegisterService = new();
            var users = await directorRegisterService.GetAllAsync();
            foreach(var user in users)
                usersNameCombo.Items.Add(user.FullName);
            if (usersNameCombo.Text.Length == 0 && datePicker.Text.Length > 0)
            {
                var dateTime = DateTime.Parse(datePicker.Text);
                ProductsDgUi.ItemsSource = ChecksPages.OrderByDescending(x => DateTime.Parse(x.Date))
                    .Where(x => DateTime.Parse(x.Date).Date == dateTime.Date);
            }
            else if(usersNameCombo.Text.Length > 0 && datePicker.Text.Length == 0)
                ProductsDgUi.ItemsSource = ChecksPages.OrderByDescending(x => DateTime.Parse(x.Date))
                    .Where(x => x.Caisher == usersNameCombo.Text);
            else if(usersNameCombo.Text.Length > 0 && datePicker.Text.Length > 0)
                ProductsDgUi.ItemsSource = ChecksPages.OrderByDescending(x => DateTime.Parse(x.Date))
                    .Where(x => x.Caisher == usersNameCombo.Text && DateTime.Parse(x.Date).Date == DateTime.Parse(datePicker.Text).Date);
            else
                ProductsDgUi.ItemsSource = (await check.GetChecksViews()).OrderByDescending(x=>DateTime.Parse(x.Date));
        }
        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(hiddenHelper);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(hiddenHelper);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void hiddenHelper_Click(object sender, RoutedEventArgs e)
        {
            Click();
        }
    }
}
