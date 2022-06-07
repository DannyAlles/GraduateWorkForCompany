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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        MedContext _context;
        HashSevice _hashSevice;
        private Client client;

        public EditClientPage()
        {
            InitializeComponent();
            _context = new MedContext();
            _hashSevice = new HashSevice();
            client = _context.Clients.FirstOrDefault(x => x.Id == Settings.Default.ClientId);
            ClientG.DataContext = client;
            BirthDP.SelectedDate = client.BirthAt;
            if (client.Gender == Data.Models.Gender.Male) MaleRB.IsChecked = true;
            else FemRB.IsChecked = true;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new ClientAccountPage());
        }

        private void SaveBT_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordTB.Password.Length != 0)
            {
                if (PasswordTB.Password == RePasswordTB.Password)
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                        client.Password = _hashSevice.GetHash(sha256Hash, PasswordTB.Password);
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new PasswordNotEqualException();
                }
            }

            client.Gender = FemRB.IsChecked.Value ? Gender.Female : Gender.Male;
            client.BirthAt = BirthDP.SelectedDate.Value;

            _context.SaveChanges();
            ManagerFrame.Frame.Navigate(new ClientAccountPage());
        }
    }
}
