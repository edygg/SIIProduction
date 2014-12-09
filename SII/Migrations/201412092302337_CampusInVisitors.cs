namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampusInVisitors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "CampusId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Visitors", "CampusId", "dbo.Campus", "Id", cascadeDelete: false);
            CreateIndex("dbo.Visitors", "CampusId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Visitors", new[] { "CampusId" });
            DropForeignKey("dbo.Visitors", "CampusId", "dbo.Campus");
            DropColumn("dbo.Visitors", "CampusId");
        }
    }
}
