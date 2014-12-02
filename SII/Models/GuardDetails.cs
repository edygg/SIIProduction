using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class GuardDetails : BaseModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Campus")]
        public int CampusId { get; set; }
        [Required]
        [Display(Name = "Tipo de entrada")]
        public String TypeEntrance { get; set; }
    }
}