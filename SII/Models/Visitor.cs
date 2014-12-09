using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Visitor : BaseModel
    {
        [Required]
        [Display(Name = "Identidad")]
        [StringLength(15, ErrorMessage = "La identidad no tiene el largo adecuado.")]
        [RegularExpression(@"^\d\d\d\d-\d\d\d\d-\d\d\d\d\d$", ErrorMessage = "El número de identidad no es válido.")]
        public String Identity { get; set; }

        [Required]
        [Display(Name = "Tipo de identidad")]
        public String IdentityType { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "Nombre demasiado largo.", MinimumLength = 5)]
        [RegularExpression(@"^[A-Za-z\s]{5,100}$", ErrorMessage = "El nombre debe contener entre 5 y 100 caracteres solamente letras.")]
        public String Name { get; set; }

        [Required]
        public bool ReturnCarnet { get; set; }

        [Required]
        public int CampusId { get; set; }

        public ICollection<VisitorEntrance> VisitorEntrances { get; set; }
    }
}