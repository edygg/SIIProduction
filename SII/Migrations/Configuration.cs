namespace SII.Migrations
{
    using SII.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SII.Models.SIIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SII.Models.SIIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SIIContext db = new SIIContext();
            db.Campus.AddOrUpdate(p => p.Code, new Campus { Code = "PRBUNO", Name = "Campus de prueba uno", Details = "Detalles de campus de prueba uno", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Campus.AddOrUpdate(p => p.Code, new Campus { Code = "PRBDOS", Name = "Campus de prueba dos", Details = "Detalles de campus de prueba dos", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Campus.AddOrUpdate(p => p.Code, new Campus { Code = "PRBTRS", Name = "Campus de prueba tres", Details = "Detalles de campus de prueba tres", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });

            db.Announcements.AddOrUpdate(p => p.Id, new Announcement { Id = 1, CampusId = 1, InitialDate = DateTime.Now.Date, FinalDate = DateTime.Now.Date, SpecificDays = "LMXJVSD", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Visits.AddOrUpdate(p => p.Id, new Visit { FullName = "Persona de prueba uno", AnnouncementId = 1, TypeEntrance = "vehicular", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Visits.AddOrUpdate(p => p.Id, new Visit { FullName = "Persona de prueba dos", AnnouncementId = 1, TypeEntrance = "vehicular", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Visits.AddOrUpdate(p => p.Id, new Visit { FullName = "Persona de prueba tres", AnnouncementId = 1, TypeEntrance = "vehicular", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Visits.AddOrUpdate(p => p.Id, new Visit { FullName = "Persona de prueba cuatro", AnnouncementId = 1, TypeEntrance = "vehicular", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Visits.AddOrUpdate(p => p.Id, new Visit { FullName = "Persona de prueba cinco", AnnouncementId = 1, TypeEntrance = "vehicular", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });

            db.SaveChanges();
            db.Dispose();
        }
    }
}
