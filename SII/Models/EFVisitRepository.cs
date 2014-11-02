using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class EFVisitRepository : IVisitRepository
    {
        SIIContext context = new SIIContext();

        public IQueryable<Visit> Visit
        {
            get { return context.Visits; }
        }

        public Visit save(Visit visit)
        {
            if (visit.Id == 0)
            {
                context.Visits.Add(visit);
            }
            else
            {
                context.Entry(visit).State = EntityState.Modified;
            }
            context.SaveChanges();
            return visit;
        }

        public void delete(int id)
        {
            Visit visit = context.Visits.Find(id);
            context.Visits.Remove(visit);
            context.SaveChanges();
              
        }

        public Visit Find(int id)
        {
            return context.Visits.Find(id);
        }
    }
}