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
            db.Campus.AddOrUpdate(p => p.Code, new Campus { Code = "PRBUNO", Name = "Campus de prueba uno", Details = "Detalles de campus de prueba 1", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Campus.AddOrUpdate(p => p.Code, new Campus { Code = "PRBDOS", Name = "Campus de prueba dos", Details = "Detalles de campus de prueba 2", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.Campus.AddOrUpdate(p => p.Code, new Campus { Code = "PRBTRS", Name = "Campus de prueba tres", Details = "Detalles de campus de prueba 3", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });

            // db.Announcements.AddOrUpdate(new Announcement { Id = 1, CampusId = 1, InitialDate = new DateTime(), FinalDate = new DateTime(), Observations = "Observaciones de visita 1", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            // db.Visits.AddOrUpdate(new Visit { Id = 1, AnnouncementId = 1, FullName = "Juan Perez", TypeEntrance = "Peatonal", CreatedAt = new DateTime(), CreatedBy = "Default", UpdatedBy = "Default", UpdatedAt = new DateTime() });
            db.SaveChanges();
            db.Dispose();
        }
    }
}
