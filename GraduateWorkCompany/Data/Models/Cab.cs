using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Data.Models
{
    public class Cab : BaseEntity
    {
        [Required]
        public string Number { get; set; }

        [MaxLength(255)]
        public string Descriptiom { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<DoctorTimetable> DoctorTimetables { get; set; }
    }
}
