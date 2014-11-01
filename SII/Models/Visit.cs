using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class Visit : BaseModel
    {
        public String FullName { get; set; }
        public String TypeEntrance { get; set; }
        public int AnnouncementId { get; set; }
    }
}