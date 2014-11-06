using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SII.Models
{
    public class SIIContext : DbContext
    {
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        public override int SaveChanges()
        {
            //Intercept saving changes on the context to add more processing
            var entries = this.ChangeTracker.Entries();
            var changes = entries.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in changes)
            {
                var type = entry.Entity.GetType();
 
                //Invoke a BeforeSave() method on the entity if it exists
                MethodInfo saveMethod = type.GetMethod("BeforeSave");
 
                if (null != saveMethod && saveMethod.GetParameters().Length == 0)
                {
                    saveMethod.Invoke(entry.Entity, null);
                }
 
                //Set the created and updated at properties if they exist
                PropertyInfo property = null;
                if (entry.State == EntityState.Added)
                {
                    property = type.GetProperty("CreatedAt");
                    if (property != null)
                    {
                        property.SetValue(entry.Entity, DateTime.Now, null);
                    }

                    property = type.GetProperty("CreatedBy");
                    if (property != null) 
                    {
                        if (HttpContext.Current != null) {
                            property.SetValue(entry.Entity, HttpContext.Current.User.Identity.Name, null);
                        }
                    }

                }
 
                property = type.GetProperty("UpdatedAt");
                if (property != null)
                {
                    property.SetValue(entry.Entity, DateTime.Now, null);
                }

                property = type.GetProperty("UpdatedBy");
                if (property != null)
                {
                    if (HttpContext.Current != null)
                    {
                        property.SetValue(entry.Entity, HttpContext.Current.User.Identity.Name, null);
                    }
                }

            }
            
            return base.SaveChanges(); //save the updates;
        }
    }
}