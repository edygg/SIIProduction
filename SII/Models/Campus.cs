using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Campus : BaseModel
    {
        [Required]
        [Display(Name = "Código")]
        public String Code { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public String Name { get; set; }
        [Display(Name = "Detalles")]
        public String Details { get; set; }
    }
}