using GraduateWorkCompany.Data;
using GraduateWorkCompany.Data.Models;
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
    /// Логика взаимодействия для RegistryMakeAnAppointmentPage.xaml
    /// </summary>
    public partial class RegistryMakeAnAppointmentPage : Page
    {
        private readonly MedContext _medContext;
        private string time;

        public RegistryMakeAnAppointmentPage()
        {
            _medContext = new MedContext();
            InitializeComponent();
            Date.DisplayDateStart = DateTime.Today;
            Doctors.ItemsSource = _medContext.Doctors.ToList();
            Clients.ItemsSource = _medContext.Clients.ToList();
        }

        private void Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date.SelectedDate != null && Doctors.SelectedItem != null)
            {
                GenerateTime();
            }
        }

        private void Doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date.SelectedDate != null && Clients.SelectedItem != null)
            {
                GenerateTime();
            }
        }

        private void MakeAnAppointmentBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Doctors.SelectedItem != null)
                {
                    if (Date.SelectedDate != null)
                    {
                        if (Clients.SelectedItem != null)
                        {

                            if (!String.IsNullOrEmpty(time))
                            {
                                var doctorId = Guid.Parse(Doctors.SelectedValue.ToString());
                                var clientId = Guid.Parse(Clients.SelectedValue.ToString());
                                var cabId = _medContext.Doctors.FirstOrDefault(x => x.Id == doctorId).CabId;
                                var appointment = new Appointment()
                                {
                                    Id = Guid.NewGuid(),
                                    CabId = cabId,
                                    ClientId = clientId,
                                    DoctorId = doctorId,
                                };
                                DateTime date = Date.SelectedDate.Value;
                                double hours = Convert.ToInt32(time.Split(':')[0]);
                                double minutes = Convert.ToInt32(time.Split(':')[1]);
                                DateTime a = date.AddHours(hours).AddMinutes(minutes);
                                appointment.StartsAt = a;

                                _medContext.Appointments.Add(appointment);
                                _medContext.SaveChanges();
                                ManagerFrame.Frame.Navigate(new RegistryTimetablePage());
                            }
                            else MessageBox.Show("Не было выбрано время", "Запись", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("Не был выбран клиент", "Запись", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Не выбрана дата", "Запись", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Доктор не был выбран", "Запись", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {

                MessageBox.Show("Что-то пошло не так", "Запись", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateTime()
        {
            TimeStack.Children.Clear();
            var doctorId = Guid.Parse(Doctors.SelectedValue.ToString());
            var date = Date.SelectedDate.Value.Date;
            var appointments = _medContext.Appointments
                .Where(x => x.DoctorId == doctorId && x.StartsAt.Day == date.Day && x.StartsAt.Month == date.Month && x.StartsAt.Year == date.Year).ToList();
            for (int i = 8; i <= 15; i++)
            {
                StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
                for (int j = 0; j <= 45; j += 15)
                {
                    if (!appointments.Any(x => x.StartsAt.Hour == i && x.StartsAt.Minute == j))
                    {
                        if (DateTime.Now.Date < Date.SelectedDate || (DateTime.Now.Hour <= i && DateTime.Now.Minute <= j))
                        {
                            RadioButton rb = new RadioButton() { GroupName = "Time", Content = $"{i}:{j}" + (j == 0 ? "0" : ""), FontSize = 15 };
                            rb.Checked += (senderobj, args) =>
                            {
                                time = ((senderobj as RadioButton).Content).ToString();
                            };
                            sp.Children.Add(rb);
                        }
                    }
                }
                TimeStack.Children.Add(sp);
            }
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Doctors.SelectedItem != null && Clients.SelectedItem != null)
            {
                GenerateTime();
            }
        }
    }
}
