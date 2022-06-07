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
    /// Логика взаимодействия для ClientMenuPage.xaml
    /// </summary>
    public partial class ClientMenuPage : Page
    {
        public ClientMenuPage()
        {
            InitializeComponent();
        }

        private void AccountBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new ClientAccountPage());
        }

        private void TimetableBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new TimetablePage());
        }
    }
}
