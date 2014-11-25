using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Department : BaseModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Ingrese un número de máximo 100 caracteres.", MinimumLength = 2)]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[A-Za-z\s]{2,100}$", ErrorMessage = "Ingrese un nombre que contenga de 2 a 100 caracteres letras solamente.")]
        public String Name { get; set; }
    }
}