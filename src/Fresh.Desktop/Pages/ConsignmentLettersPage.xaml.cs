using Fresh.Desktop.Windows;
using Fresh.Service.Director;
using Fresh.Service.Services.PageServices;
using Fresh.Service.ViewModels;
using Fresh.Service.ViewModels.ViewDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
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
        public static List<ConsigmentLetterViewDetails> consigmentLetterDetailsView = new();

        private void DatePicker_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(hiddenHelper);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }
        private async void SetValues()
        {
            Service.Services.PageServices.ConsignmentLettersPage consignmentLettersPage = new();
            var result = await consignmentLettersPage.GetAllCL();
            DirectorRegisterService directorRegisterService = new();
            var users = await directorRegisterService.GetAllAsync();
            foreach (var user in users)
            {
                if (user.IsAdmin == 0)
                    usersNameCombo.Items.Add(user.FullName);
            }
            if (usersNameCombo.Text.Length == 0 && datePicker.Text.Length > 0)
            {
                var dateTime = DateTime.Parse(datePicker.Text);
                ProductsDgUi.ItemsSource = result.OrderByDescending(x => x.DateTime)
                    .Where(x => x.DateTime.Date == dateTime.Date);
            }
            else if (usersNameCombo.Text.Length > 0 && datePicker.Text.Length == 0)
                ProductsDgUi.ItemsSource = result.OrderByDescending(x => x.DateTime)
                    .Where(x => x.Cashier == usersNameCombo.Text);
            else if (usersNameCombo.Text.Length > 0 && datePicker.Text.Length > 0)
                ProductsDgUi.ItemsSource = result.OrderByDescending(x => x.DateTime)
                    .Where(x => x.Cashier == usersNameCombo.Text && x.DateTime.Date == DateTime.Parse(datePicker.Text).Date);
            else
                ProductsDgUi.ItemsSource = (await consignmentLettersPage.GetAllCL()).OrderByDescending(x => x.DateTime);
        }

        private async void RowDouble_Clicked(object sender, MouseButtonEventArgs e)
        {
            ConsignmentLetterView consigmentLetterView = (ConsignmentLetterView)ProductsDgUi.SelectedItem;
            Service.Services.PageServices.ConsignmentLettersPage consPage = new();
            consigmentLetterDetailsView = await consPage.GetConsigmentLetterDetailsById(consigmentLetterView.Id);
            ConsignmentLetterDescription consignmentLetterDescription = new ConsignmentLetterDescription();
            consignmentLetterDescription.ShowDialog();
        }

        private void ProductsDgUi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void hiddenHelper_Click(object sender, RoutedEventArgs e)
        {
            SetValues();
        }

        private void usersNameCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(hiddenHelper);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }
    }
}
