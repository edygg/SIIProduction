using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SII.Models
{
    public class EFCampusRepository :ICampusRepository
    {
        SIIContext context = new SIIContext();

        public IQueryable<Campus> Campus
        {
            get { return context.Campus;  }
        }

        public Campus save(Campus campus)
        {
            if ( campus.Id == 0 )
            {
                context.Campus.Add(campus);
            }
            else
            {
                context.Entry(campus).State = EntityState.Modified;
            }
            context.SaveChanges();
            return campus;
        }

        public void delete(int id )
        {
           Campus campus = context.Campus.Find(id);
           campus.Dropped = true;
           context.Entry(campus).State = EntityState.Modified;
           context.SaveChanges();
              
              
        }

        public Campus Find(int id = 0)
        {
            return context.Campus.Find(id);       
        }
    }
}