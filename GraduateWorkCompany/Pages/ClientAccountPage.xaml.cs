using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Domain.Services;
using GraduateWorkCompany.Properties;
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

namespace GraduateWorkCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientAccountPage.xaml
    /// </summary>
    public partial class ClientAccountPage : Page
    {
        private readonly ClientService _clientService;

        public ClientAccountPage()
        {
            InitializeComponent();
            _clientService = new ClientService();
            var client = _clientService.GetClientById(Settings.Default.ClientId);

            FIO.Text = client.FIO;
            Login.Text = client.Login;
            OMS.Text = client.OMS;
            BirthDate.Text = client.BirthAt.ToShortDateString();
            Gender.Text = client.Gender == Data.Models.Gender.Male ? "Мужской" : "Женский";
            Seria.Text = client.Seria;
            Number.Text = client.Number;
            Phone.Text = client.Phone;
        }

        private void LogoutBT_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.ClientId != Guid.Empty)
            {
                if (MessageBox.Show("Выйти из аккаунта?", "Аккаунт", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Settings.Default.ClientId = Guid.Empty;
                    Settings.Default.ClientFIO = String.Empty;
                    Settings.Default.Save();
                    ManagerFrame.Frame.Navigate(new AuthorizationPage());
                    ManagerFrame.MenuFrame.Navigate(null);
                }
            }
        }

        private void ChangeBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new EditClientPage());
        }
    }
}
