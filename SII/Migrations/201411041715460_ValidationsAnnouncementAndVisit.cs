namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationsAnnouncementAndVisit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "Observations", c => c.String(maxLength: 150));
            AlterColumn("dbo.Visits", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Visits", "TypeEntrance", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "TypeEntrance", c => c.String());
            AlterColumn("dbo.Visits", "FullName", c => c.String());
            AlterColumn("dbo.Announcements", "Observations", c => c.String());
        }
    }
}
