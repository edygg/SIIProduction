using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public String CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}