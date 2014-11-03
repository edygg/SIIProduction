using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public interface IAnnouncementRepository
    {
        IQueryable<Announcement> Announcements { get; }
        Announcement save(Announcement announcement);
        void delete(int id);
        Announcement Find(int id);
    }
}