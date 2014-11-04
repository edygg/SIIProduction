using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Visit : BaseModel
    {
        [Required]
        [Display(Name = "Nombre completo")]
        [StringLength(100, ErrorMessage = "El {0} debe de ser de al menos {2} caracteres de largo.", MinimumLength = 5)]
        [RegularExpression(@"^[A-Za-z\s]{5,100}$", ErrorMessage = "Ingrese hasta 100 caracteres, que pueden ser letras mayúsculas o minúsculas.")]
        public String FullName { get; set; }

        [Required]
        [Display(Name = "Tipo de entrada")]
        public String TypeEntrance { get; set; }

        [Required]
        public int AnnouncementId { get; set; }
    }
}