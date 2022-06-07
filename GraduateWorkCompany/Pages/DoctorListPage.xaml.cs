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
    /// Логика взаимодействия для DoctorListPage.xaml
    /// </summary>
    public partial class DoctorListPage : Page
    {
        MedContext context;
        Doctor NewDoctor = new Doctor();
        Doctor SelectedDoctor = new Doctor();

        public DoctorListPage()
        {
            this.context = new MedContext();
            InitializeComponent();
            GetDoctors();
            NewDoctor = new Doctor();
            NewDoctorGrid.DataContext = NewDoctor;
        }

        private void GetDoctors()
        {
            DoctorDG.ItemsSource = context.Doctors.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            NewDoctor.Id = Guid.NewGuid();
            NewDoctor.CreataedById = Settings.Default.ClientId;
            context.Doctors.Add(NewDoctor);
            context.SaveChanges();
            GetDoctors();
            NewDoctor = new Doctor();
            NewDoctorGrid.DataContext = NewDoctor;
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.SaveChanges();
            GetDoctors();
        }

        private void SelectDoctorToEdit(object s, RoutedEventArgs e)
        {
            SelectedDoctor = (s as FrameworkElement).DataContext as Doctor;
            UpdateDoctorGrid.DataContext = SelectedDoctor;
        }

        private void DeleteDoctor(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Doctor;
            context.Doctors.Remove(productToDelete);
            context.SaveChanges();
            GetDoctors();
        }
    }
}
