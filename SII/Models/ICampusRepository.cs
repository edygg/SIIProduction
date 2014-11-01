using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public interface ICampusRepository
    {
        IQueryable<Campus> Campus { get; }
        Campus save(Campus campus);
        void delete(Campus campus);
    }
}