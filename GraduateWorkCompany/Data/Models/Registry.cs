using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Data.Models
{
    public class Registry : BaseEntity
    {
        [Required(ErrorMessage = "Не указан номер телефона")]
        [MaxLength(12)]
        [RegularExpression(@"^(7([0-6]|[8-9])[0-9]{9})$",
            ErrorMessage = "Неверный формат номера")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Login { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Ф.И.О.")]
        public string FIO { get; set; }
    }
}
