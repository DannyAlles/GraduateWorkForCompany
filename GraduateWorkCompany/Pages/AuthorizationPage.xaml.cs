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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private async void AuthoriBT_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var clientService = new ClientService();
                
                var client = await clientService.GetClientByLogin(LoginTB.Text).ConfigureAwait(false);
                
                if (client != null)
                {
                    await clientService.Authorize(client, PasswordTB.Password).ConfigureAwait(false);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ManagerFrame.frame.Navigate(new TimetablePage());
                    });
                }
                else MessageBox.Show("Пользователь не найден", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PasswordNotEqualException)
            {
                MessageBox.Show("Неверный пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegistrationBT_Click(object sender, RoutedEventArgs e) 
        {
            ManagerFrame.frame.Navigate(new RegistrationPage());
        }
    }
}
