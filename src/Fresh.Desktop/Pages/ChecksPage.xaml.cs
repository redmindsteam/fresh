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
    /// Interaction logic for ChecksPage.xaml
    /// </summary>
    public partial class ChecksPage : Page
    {
        public ChecksPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void comboBoxCashiers_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
