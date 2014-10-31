using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public String CreatedBy { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedAt { get; set; }
        public String UpdatedBy { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? UpdatedAt { get; set; }

    }
}