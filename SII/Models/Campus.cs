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
        [StringLength(6, ErrorMessage = "Ingrese un código de 6 caracteres que contenga solo letras mayúsculas.")]
        [RegularExpression(@"^[A-Z]{6}$", ErrorMessage = "Ingrese un código de 6 caracteres que contenga solo letras mayúsculas.")]
        public String Code { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El {0} debe de ser de al menos {2} caracteres de largo.", MinimumLength = 5)]
        [RegularExpression(@"^[A-Za-z\s]{1,50}$", ErrorMessage = "Ingrese hasta 50 caracteres, que pueden ser letras mayúsculas o minúsculas.")]
        [Display(Name = "Nombre")]
        public String Name { get; set; }

        [Display(Name = "Detalles")]
        [StringLength(150, ErrorMessage = "Se permiten solamente 150 caracteres", MinimumLength = 0)]
        [RegularExpression(@"^[a-zA-z\s\,\.]{0,150}$", ErrorMessage = "Ingrese hasta 150 caracteres, que pueden ser letras, puntos o comas")]
        public String Details { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
    }
}