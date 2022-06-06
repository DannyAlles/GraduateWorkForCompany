using System;
using System.Windows;
using System.Windows.Input;
using GraduateWorkCompany.Domain.Services;
using GraduateWorkCompany.Pages;
using GraduateWorkCompany.Properties;

namespace GraduateWorkCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClientService _clientService;
            
        public MainWindow()
        {
            InitializeComponent();
            _clientService = new ClientService();
            ManagerFrame.frame = MainFrame;
            if (Settings.Default.UserId == Guid.Empty)
                ManagerFrame.frame.Navigate(new AuthorizationPage());
            else LoginLB.Text = Settings.Default.UserLogin;
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int id = MenuList.SelectedIndex;

            switch (id)
            {

                case 0:
                    {
                        //Auth(new CreatePage());
                        break;
                    }
                case 1:
                    {
                        //Auth(new PrintPage());
                        break;
                    }
                case 2:
                    {
                        //Auth(new ListPage());
                        break;
                    }
                case 3:
                    {
                        //ManagerFrame.frame.Navigate(new SettingsPage());
                        break;
                    }
                case 4:
                    {
                       
                        break;
                    }
                default:
                    MessageBox.Show("Ошибка выбора пункта меню", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.UserId != Guid.Empty)
            {
                if (MessageBox.Show("Выйти из аккаунта?", "Аккаунт", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Settings.Default.UserId = Guid.Empty;
                    Settings.Default.UserLogin = String.Empty;
                    Settings.Default.Save();
                    LoginLB.Text = "Войти";
                }
            }
            else
            {
                Settings.Default.UserId = Guid.NewGuid();
                Settings.Default.UserLogin = "test";
            }
        }
    }
}
