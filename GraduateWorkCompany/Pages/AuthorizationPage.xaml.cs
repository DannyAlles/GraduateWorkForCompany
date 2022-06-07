using GraduateWorkCompany.Domain.Exception;
using GraduateWorkCompany.Domain.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private bool IsRegistry = false;
        private readonly ClientService _clientService;
        private readonly RegistryService _registryService;

        public AuthorizationPage()
        {
            InitializeComponent();
            _clientService = new ClientService();
            _registryService = new RegistryService();
        }

        private async void AuthoriBT_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!IsRegistry)
                {
                    var client = await _clientService.GetClientByLogin(LoginTB.Text).ConfigureAwait(false);

                    if (client != null)
                    {
                        await _clientService.Authorize(client, PasswordTB.Password).ConfigureAwait(false);

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ManagerFrame.Frame.Navigate(new TimetablePage());
                            ManagerFrame.MenuFrame.Navigate(new ClientMenuPage());
                        });
                    }
                    else MessageBox.Show("Пользователь не найден", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var registry = await _registryService.GetRegistryByLogin(LoginTB.Text).ConfigureAwait(false);

                    if(registry != null)
                    {
                        await _registryService.Authorize(registry, PasswordTB.Password).ConfigureAwait(false);

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ManagerFrame.Frame.Navigate(new TimetablePage());
                            ManagerFrame.MenuFrame.Navigate(new RegistryMenuPage());
                        });
                    }
                    else MessageBox.Show("Пользователь не найден", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (PasswordNotEqualException)
            {
                MessageBox.Show("Неверный пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegistrationBT_Click(object sender, RoutedEventArgs e) 
        {
            if(!IsRegistry) ManagerFrame.Frame.Navigate(new RegistrationPage());
            else ManagerFrame.Frame.Navigate(new RegistryRegistrationPage());
        }

        private void RegistryBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(!IsRegistry)
            {
                bool isRegistrationAvailable = Convert.ToBoolean(ConfigurationManager.AppSettings["IsRegistrationAvailable"].ToString());
                AccountTypeLabel.Content = "Сотрудник регистратуры";
                RegistryBT.Text = "Войти как клиент";
                RegistrationBT.Visibility = !isRegistrationAvailable ? Visibility.Hidden : Visibility.Visible;
                IsRegistry = true;
            }
            else
            {
                AccountTypeLabel.Content = "Клиент";
                RegistryBT.Text = "Войти как сотрудник регистратуры";
                RegistrationBT.Visibility = Visibility.Visible;
                IsRegistry = false;
            }
        }
    }
}
