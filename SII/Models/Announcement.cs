using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Announcement : BaseModel
    {
        [Required]
        [Display(Name = "Campus")]
        public int CampusId { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        public DateTime InitialDate { get; set; }

        [Required]
        [Display(Name = "Fecha final")]
        public DateTime FinalDate { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(150, ErrorMessage = "Se permiten 150 caracteres máximo", MinimumLength = 0)]
        [RegularExpression(@"^[\w\s\,\.\:\-\(\)_\@]{0,150}$", ErrorMessage = "Ingrese hasta 150 caracteres (letras, números y signos de puntuación)")]
        public String Observations { get; set; }

        public String SpecificDays { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}