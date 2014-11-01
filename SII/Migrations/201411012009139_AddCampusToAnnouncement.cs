namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampusToAnnouncement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "CampusId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Announcements", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
            CreateIndex("dbo.Announcements", "CampusId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Announcements", new[] { "CampusId" });
            DropForeignKey("dbo.Announcements", "CampusId", "dbo.Campus");
            DropColumn("dbo.Announcements", "CampusId");
        }
    }
}
