using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public interface IBarrierRepository
    {
        IQueryable<Barrier> Barriers { get; }
        Barrier save(Barrier barrier);
        void delete(int id);
        Barrier Find(int id);
    }
}