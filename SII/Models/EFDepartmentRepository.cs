using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SII.Models
{
    public class EFDepartmentRepository : IDeparmentRepository
    {
        SIIContext context= new SIIContext();
        public IQueryable<Department> Departments
        {
            get { return context.Departments;  }
        }

        public Department save(Department department)
        {
            if (department.Id == 0)
            {
                context.Departments.Add(department);
            }
            else
            {
                context.Entry(department).State = EntityState.Modified;
            }
            context.SaveChanges();
            return department;
        }

        public void delete(int id)
        {
            Department dep = context.Departments.Find(id);
            dep.Dropped = true;
            context.Entry(dep).State = EntityState.Modified;
            context.SaveChanges(); 
        }

        public Department Find(int id)
        {
            return context.Departments.Find(id);
        }
    }
}