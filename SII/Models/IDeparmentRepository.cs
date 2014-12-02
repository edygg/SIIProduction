using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public interface IDeparmentRepository
    {
        IQueryable<Department> Departments { get; }
        Department save(Department department);
        void delete(int id);
        Department Find(int id);
    }
}