using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class VisitorEntrance : BaseModel
    {
        [Required]
        [Display(Name = "Visitante")]
        public int VisitorId { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "No. carnet")]
        public int CarnetId { get; set; }

        [Display(Name = "Estado")]
        public String State { get; set; }
    }
}