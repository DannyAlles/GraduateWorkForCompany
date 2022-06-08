using GraduateWorkCompany.Data;
using GraduateWorkCompany.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RegistryTimetablePage.xaml
    /// </summary>
    public partial class RegistryTimetablePage : Page
    {
        private MedContext medContext;
        List<Doctor> doctors = new List<Doctor>();
        DataTable myTable = new DataTable();

        public RegistryTimetablePage()
        {
            InitializeComponent();
            medContext = new MedContext();

            DateP.SelectedDate = DateTime.Today;
            TimeDataGrid.DataContext = myTable;
        }

        private void SetDG()
        {
            TimeDataGrid.DataContext = myTable;
            myTable = new DataTable();
            doctors = medContext.Doctors.ToList();

            myTable.Columns.Add("Время");
            foreach (var item in doctors)
            {
                myTable.Columns.Add(item.FIO);
            }

            for (int i = 8; i <= 15; i++)
            {
                for (int j = 0; j <= 45; j += 15)
                {
                    string time = $"{i}:" + (j == 0 ? "00" : $"{j}");
                    DataRow row = myTable.NewRow();

                    List<string> strings = new List<string>();
                    strings.Add(time);
                    DateTime dateTime = DateP.SelectedDate.Value.AddHours(i).AddMinutes(j);
                    foreach (var item in doctors)
                    {
                        var client = medContext.Appointments.Include(x => x.Client).FirstOrDefault(x => x.DoctorId == item.Id && x.StartsAt == dateTime)?.Client;
                        if (client != null) strings.Add(client.FIO);
                        else strings.Add("");
                    }

                    myTable.Rows.Add(strings.ToArray());
                }
            }

            TimeDataGrid.DataContext = myTable;
        }

        private void DateP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetDG();
        }
    }
}
