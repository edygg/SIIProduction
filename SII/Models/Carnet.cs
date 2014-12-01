using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Carnet : BaseModel
    {
        [Required]
        [Display(Name = "Número")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Debe ingresar un número desde uno en adelante.")]
        public int Number { get; set; }
        [Required]
        [Display(Name = "Campus")]
        public int CampusId { get; set; }
        [Display(Name = "Ocupado")]
        public bool Taken { get; set; }
    }
}