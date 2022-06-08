using GraduateWorkCompany.Data;
using System;
using System.Collections.Generic;
using System.Data;
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

        public RegistryTimetablePage()
        {
            InitializeComponent();
            medContext = new MedContext();

            TimeDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Время"
            });

            foreach (var item in medContext.Doctors.Select(x => x.FIO).ToList())
            {
                TimeDataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = item
                });
            }

            for (int i = 8; i <= 15; i++)
            {
                for (int j = 0; j <= 45; j += 15)
                {
                }
            }
        }
    }
}
