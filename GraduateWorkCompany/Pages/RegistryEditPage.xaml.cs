using GraduateWorkCompany.Data;
using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Domain.Exception;
using GraduateWorkCompany.Domain.Services;
using GraduateWorkCompany.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для RegistryEditPage.xaml
    /// </summary>
    public partial class RegistryEditPage : Page
    {
        MedContext _context;
        HashSevice _hashSevice;
        private Registry registry;

        public RegistryEditPage()
        {
            InitializeComponent();
            _context = new MedContext();
            _hashSevice = new HashSevice();
            registry = _context.Registries.FirstOrDefault(x => x.Id == Settings.Default.ClientId);
            RegistryG.DataContext = registry;
        }

        private void SaveBT_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTB.Password.Length != 0)
            {
                if (PasswordTB.Password == RePasswordTB.Password)
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                        registry.Password = _hashSevice.GetHash(sha256Hash, PasswordTB.Password);
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            _context.SaveChanges();
            ManagerFrame.Frame.Navigate(new RegistryAccountPage());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new RegistryAccountPage());
        }
    }
}
