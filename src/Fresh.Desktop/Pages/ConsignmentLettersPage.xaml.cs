using Fresh.Desktop.Windows;
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
    /// Interaction logic for ConsignmentLettersPage.xaml
    /// </summary>
    public partial class ConsignmentLettersPage : Page
    {
        public ConsignmentLettersPage()
        {
            InitializeComponent();
            SetValues();
        }

        private void DatePicker_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private async void SetValues()
        {
            Service.Services.PageServices.ConsignmentLettersPage consignmentLettersPage = new();
            var result = await consignmentLettersPage.GetAllCL();
            ProductsDgUi.ItemsSource = result.OrderByDescending(x=>x.DateTime);
        }

        private void RowDouble_Clicked(object sender, MouseButtonEventArgs e)
        {
            ConsignmentLetterDescription consignmentLetterDescription = new ConsignmentLetterDescription();
            consignmentLetterDescription.ShowDialog();
        }

        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
