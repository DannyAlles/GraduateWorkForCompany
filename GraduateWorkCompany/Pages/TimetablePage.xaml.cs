using GraduateWorkCompany.Data;
using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Properties;
using GraduateWorkCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private string time;
        Appointment SelectedAppointment = new Appointment();

        public TimetablePage()
        {
            InitializeComponent();
            this._context = new MedContext();
            GetAppointments();
            Doctors.ItemsSource = _context.Doctors.ToList();
        }

        private void GenerateTime()
        {
            var doctorId = Guid.Parse(Doctors.SelectedValue.ToString());
            var date = Date.SelectedDate.Value.Date;
            TimeStack.Children.Clear();
            var appointments = _context.Appointments
                .Where(x => x.DoctorId == doctorId && x.StartsAt.Day == date.Day && x.StartsAt.Month == date.Month && x.StartsAt.Year == date.Year).ToList();
            for (int i = 8; i <= 15; i++)
            {
                StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
                for (int j = 0; j <= 45; j += 15)
                {
                    if (!appointments.Any(x => x.StartsAt.Hour == i && x.StartsAt.Minute == j))
                    {
                        RadioButton rb = new RadioButton() { GroupName = "Time", Content = $"{i}:{j}" + (j == 0 ? "0" : ""), FontSize = 15};
                        rb.Checked += (senderobj, args) =>
                        {
                            time = ((senderobj as RadioButton).Content).ToString();
                        };
                        sp.Children.Add(rb);
                    }
                }
                TimeStack.Children.Add(sp);
            }
        }


        private void GetAppointments()
        {
            var appointments = _context.Appointments.Where(x => x.ClientId == Settings.Default.ClientId)
                 .OrderBy(x => x.StartsAt)
                 .Include(x => x.Doctor)
                 .Include(x => x.Cab).ToList();
            AppointmentDG.ItemsSource = appointments;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Doctors.SelectedItem != null)
            {
                GenerateTime();
            }
        }

        private void Doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date.SelectedDate != null)
            {
                GenerateTime();
            }
        }

        private void MakeAnAppointmentBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Frame.Navigate(new MakeAnAppointmentPage());
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            DateTime date = Date.SelectedDate.Value.Date;
            double hours = Convert.ToInt32(time.Split(':')[0]);
            double minutes = Convert.ToInt32(time.Split(':')[1]);
            DateTime a = date.AddHours(hours).AddMinutes(minutes);
            SelectedAppointment.StartsAt = a;

            _context.SaveChanges(); 
            GetAppointments();
        }

        private void SelectAppointmentToEdit(object s, RoutedEventArgs e)
        {
            SelectedAppointment = (s as FrameworkElement).DataContext as Appointment;
            UpdateAppointmentGrid.DataContext = SelectedAppointment;
        }

        private void DeleteAppointment(object s, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены что хотите отменить запись?", "Запись", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                var productToDelete = (s as FrameworkElement).DataContext as Appointment;
                _context.Appointments.Remove(productToDelete);
                _context.SaveChanges();
                GetAppointments();
            }
        }
    }
}
