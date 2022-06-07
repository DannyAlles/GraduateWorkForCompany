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
    /// Логика взаимодействия для RegistryMenuPage.xaml
    /// </summary>
    public partial class RegistryMenuPage : Page
    {
        public RegistryMenuPage()
        {
            InitializeComponent();
        }

        private void AccountBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new RegistryAccountPage());
        }

        private void CabBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new CarListPage());
        }

        private void DoctorBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new DoctorListPage());
        }
    }
}
