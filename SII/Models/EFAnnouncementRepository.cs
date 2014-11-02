using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class EFAnnouncementRepository : IAnnouncementRepository
    {
        SIIContext context = new SIIContext();

        public IQueryable<Announcement> Announcement
        {
            get { return context.Announcements; }
        }

        public Announcement save(Announcement announcement)
        {
            if (announcement.Id == 0)
            {
                context.Announcements.Add(announcement);
            }
            else
            {
                context.Entry(announcement).State = EntityState.Modified;
            }
            context.SaveChanges();
            return announcement;
        }

        public void delete(int id)
        {
            Announcement announcement = context.Announcements.Find(id);
            context.Announcements.Remove(announcement);
            context.SaveChanges();
        }

        public Announcement Find(int id)
        {
            return context.Announcements.Find(id);
        }
    }
}