using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.ViewModels
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public string Doctor { get; set; }
        public string Date { get; set; }
        public string Cab { get; set; }
    }
}
