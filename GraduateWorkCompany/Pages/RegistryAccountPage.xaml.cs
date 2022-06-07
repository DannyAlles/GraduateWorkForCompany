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
    /// Логика взаимодействия для RegistryAccountPage.xaml
    /// </summary>
    public partial class RegistryAccountPage : Page
    {
        private readonly RegistryService _registryService;
        public Task Initialization { get; private set; }

        public RegistryAccountPage()
        {
            InitializeComponent();
            _registryService = new RegistryService();

            var registry = _registryService.GetRegistryById(Settings.Default.ClientId);

            FIO.Text = registry.FIO;
            Login.Text = registry.Login;
            Phone.Text = registry.Phone;
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
    }
}