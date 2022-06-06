using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Domain.Exception;
using GraduateWorkCompany.Domain.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GraduateWorkCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly ClientService _clientService;

        public RegistrationPage()
        {
            InitializeComponent();
            _clientService = new ClientService();
        }

        private async void RegistrationBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client()
                {
                    FIO = FIOTB.Text,
                    Login = LoginTB.Text,
                    Number = NumberTB.Text,
                    Seria = SeriaTB.Text,
                    Phone = PhoneTB.Text,
                    Gender = FemRB.IsChecked.Value ? Gender.Female : Gender.Male,
                    BirthAt = BirthDP.SelectedDate.Value,
                    CreatedAt = DateTime.UtcNow,
                };

                await _clientService.CreateClient(client, RePasswordTB.Password, PasswordTB.Password).ConfigureAwait(false);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    ManagerFrame.frame.Navigate(new AuthorizationPage());
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
            ManagerFrame.frame.Navigate(new AuthorizationPage());
        }
    }
}
