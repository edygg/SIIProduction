using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Entrance : BaseModel
    {
        [Required]
        public int VisitId { get; set; }

        [Required]
        public String State { get; set; }
    }
}