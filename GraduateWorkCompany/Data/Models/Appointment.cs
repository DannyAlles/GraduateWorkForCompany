using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Data.Models
{
    public class Appointment : BaseEntity
    {
        [Required]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public Guid CabId { get; set; }
        public Cab Cab { get; set; }

        [Required]
        public DateTime StartsAt { get; set; }
    }
}
