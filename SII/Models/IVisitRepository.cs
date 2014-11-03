using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public interface IVisitRepository
    {

        IQueryable<Visit> Visits { get; }
        Visit save(Visit visit);
        void delete(int id);
        Visit Find(int id);
    
    }
}