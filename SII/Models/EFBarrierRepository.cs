using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class EFBarrierRepository : IBarrierRepository
    {
        SIIContext context = new SIIContext();
        public IQueryable<Barrier> Barriers
        {
            get { return context.Barriers; }
        }

        public Barrier save(Barrier barrier)
        {
            if( barrier.Id == 0 )
            {
                context.Barriers.Add(barrier);
            }else
            {
                 context.Entry(barrier).State = EntityState.Modified;
            }
            context.SaveChanges();
            return barrier;
        }

        public void delete(int id)
        {
            Barrier barrier = context.Barriers.Find(id);
            barrier.Dropped = true;
            context.Entry(barrier).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Barrier Find(int id)
        {
            return context.Barriers.Find(id);
        }
    }
}


     

        
