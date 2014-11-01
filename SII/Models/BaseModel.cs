using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [Display(Name = "Creado por")]
        public String CreatedBy { get; set; }
        [Display(Name = "Fecha de creación")]
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Última actualización por")]
        public String UpdatedBy { get; set; }
        [Display(Name = "Fecha de última actualización")]
        [Column(TypeName = "DateTime2")]
        public DateTime? UpdatedAt { get; set; }
        public bool Dropped { get; set; }
    }
}