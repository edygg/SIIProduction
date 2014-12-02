using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class EFCarnetRepository : ICarnetRepository
    {
        SIIContext context = new SIIContext();

        public IQueryable<Carnet> Carnets
        {
            get { return context.Carnets; }
        }

        public Carnet save(Carnet Carnet)
        {
            if (Carnet.Id == 0)
            {
                context.Carnets.Add(Carnet);
            }
            else
            {
                context.Entry(Carnet).State = EntityState.Modified;
            }
            context.SaveChanges();
            return Carnet;
        }

        public void delete(int id)
        {
            Carnet carnet = context.Carnets.Find(id);
            carnet.Dropped = true;
            context.Entry(carnet).State = EntityState.Modified;
            context.SaveChanges();       
        }

        public Carnet Find(int id)
        {
            return context.Carnets.Find(id);
        }
    }
}