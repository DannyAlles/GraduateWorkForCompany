using GraduateWorkCompany.Data;
using GraduateWorkCompany.Data.Models;
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
    /// Логика взаимодействия для CarListPage.xaml
    /// </summary>
    public partial class CarListPage : Page
    {
        MedContext context;
        Cab NewCab = new Cab();
        Cab SelectedCab = new Cab();

        public CarListPage()
        {
            this.context = new MedContext();
            InitializeComponent();
            GetCabs();
            NewCab = new Cab();
            NewCabGrid.DataContext = NewCab;
        }

        private void GetCabs()
        {
            CabDG.ItemsSource = context.Cabs.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            NewCab.Id = Guid.NewGuid();
            context.Cabs.Add(NewCab);
            context.SaveChanges();
            GetCabs();
            NewCab = new Cab();
            NewCabGrid.DataContext = NewCab;
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.SaveChanges();
            GetCabs();
        }

        private void SelectCabToEdit(object s, RoutedEventArgs e)
        {
            SelectedCab = (s as FrameworkElement).DataContext as Cab;
            UpdateCabGrid.DataContext = SelectedCab;
        }

        private void DeleteCab(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Cab;
            context.Cabs.Remove(productToDelete);
            context.SaveChanges();
            GetCabs();
        }
    }
}
