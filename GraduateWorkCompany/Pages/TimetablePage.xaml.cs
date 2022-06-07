using GraduateWorkCompany.Data;
using GraduateWorkCompany.Properties;
using GraduateWorkCompany.ViewModels;
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
    /// Логика взаимодействия для TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        MedContext _context;

        public TimetablePage()
        {
            InitializeComponent();
            this._context = new MedContext();
        }

        private void MakeAnAppointmentBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new MakeAnAppointmentPage());
        }
    }
}
