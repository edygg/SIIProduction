using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class EFEntranceRepository :IEntranceRepository
    {
        SIIContext context = new SIIContext();
        public IQueryable<Entrance> Campus
        {
            get {return context.Entrances; }
        }

        public Entrance save(Entrance entrance)
        {
            if (entrance.Id == 0)
            {
                context.Entrances.Add(entrance);
            }
            else
            {
                context.Entry(entrance).State = EntityState.Modified;
            }
            context.SaveChanges();
            return entrance;
        }

        public void delete(int id)
        {
            Entrance entrance = context.Entrances.Find(id);
            entrance.Dropped = true;
            context.Entry(entrance).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Entrance Find(int id)
        {
              return context.Entrances.Find(id);
        }
    }
}