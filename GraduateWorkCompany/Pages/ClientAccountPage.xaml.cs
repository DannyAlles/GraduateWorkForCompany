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
        public ClientAccountPage()
        {
            InitializeComponent();
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
