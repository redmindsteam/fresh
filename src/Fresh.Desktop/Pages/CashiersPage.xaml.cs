﻿using Fresh.Desktop.Windows;
using Fresh.Domain.Entities;
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
    /// Interaction logic for CashiersPage.xaml
    /// </summary>
    public partial class CashiersPage : Page
    {
        public CashiersPage()
        {
            InitializeComponent();
        }

 

        

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteUser(object sender, RoutedEventArgs e)
        {
        
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Db_User user = new Db_User();
            user.Show();
            
        }
    }
}
