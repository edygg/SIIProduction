using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Announcement : BaseModel
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public String Observations { get; set; }
        public String SpecificDays { get; set; }
        public ICollection<Visit> Visits { get; set; }
    }
}