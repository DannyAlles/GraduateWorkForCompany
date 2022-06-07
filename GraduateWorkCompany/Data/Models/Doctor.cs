using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Data.Models
{
    public class Doctor : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string FIO { get; set; }

        [Required]
        [MaxLength(255)]
        public string Post { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public Guid CreataedById { get; set; }
        public Registry CreataedBy { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Cab> Cabs { get; set; }
        public IEnumerable<DoctorTimetable> DoctorTimetables { get; set; }

    }
}
