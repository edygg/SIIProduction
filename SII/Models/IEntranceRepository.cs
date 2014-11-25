using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
  
    public interface IEntranceRepository
    {
        IQueryable<Entrance> Campus { get; }
        Entrance save(Entrance entrance);
        void delete(int id);
        Entrance Find(int id);
    }
}