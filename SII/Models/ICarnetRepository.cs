using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public interface ICarnetRepository
    {
        IQueryable<Carnet> Carnets { get; }
        Carnet save(Carnet Carnet);
        void delete(int id);
        Carnet Find(int id);
    }
}