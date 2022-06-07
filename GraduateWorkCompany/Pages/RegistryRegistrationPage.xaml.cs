using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Domain.Exception;
using GraduateWorkCompany.Domain.Services;
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
    /// Логика взаимодействия для RegistryRegistrationPage.xaml
    /// </summary>
    public partial class RegistryRegistrationPage : Page
    {
        private readonly RegistryService _registryService;

        public RegistryRegistrationPage()
        {
            InitializeComponent();
            _registryService = new RegistryService();
        }

        private async void RegistrationBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Registry registry = new Registry()
                {
                    FIO = FIOTB.Text,
                    Login = LoginTB.Text,
                    Phone = PhoneTB.Text
                };

                await _registryService.CreateRegistry(registry, PasswordTB.Password, RePasswordTB.Password).ConfigureAwait(false);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ManagerFrame.Frame.Navigate(new AuthorizationPage());
                });
            }
            catch (PasswordNotEqualException)
            {
                MessageBox.Show("Пароли не совпадают", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Заполнены не все обязательные поля", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PasswordIsEmptyException)
            {
                MessageBox.Show("Пароль является обязательным полем", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (LoginIsAlreadyExistsException)
            {
                MessageBox.Show("Логин уже занят", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PhoneIsAlreadyExistsException)
            {
                MessageBox.Show("Телефон уже занят", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new AuthorizationPage());
        }
    }
}
