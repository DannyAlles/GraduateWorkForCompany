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

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime StartsAt { get; set; }

        [Required]
        public DateTime EndsAt { get; set; }

        public Type Type { get; set; }

        public Status Status { get; set; } = Status.Awaiting;
    }

    public enum Type
    {
        Visit,
        Custom
    }

    public enum Status
    {
        Awaiting,
        Done,
        Denied,
        Allowed,
    }
}
