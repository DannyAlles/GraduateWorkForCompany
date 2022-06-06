using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Data.Models
{
    public class BaseEntity
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Не указан Id")]
        public Guid Id { get; set; }
    }
}
