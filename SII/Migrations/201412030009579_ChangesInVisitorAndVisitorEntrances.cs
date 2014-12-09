namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInVisitorAndVisitorEntrances : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorEntrances", "CarnetId", c => c.Int(nullable: false));
            AddColumn("dbo.Visitors", "ReturnCarnet", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.VisitorEntrances", "CarnetId", "dbo.Carnets", "Id", cascadeDelete: true);
            CreateIndex("dbo.VisitorEntrances", "CarnetId");
            DropColumn("dbo.VisitorEntrances", "Carnet");
            DropColumn("dbo.VisitorEntrances", "ReturnCarnet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisitorEntrances", "ReturnCarnet", c => c.Boolean(nullable: false));
            AddColumn("dbo.VisitorEntrances", "Carnet", c => c.Int(nullable: false));
            DropIndex("dbo.VisitorEntrances", new[] { "CarnetId" });
            DropForeignKey("dbo.VisitorEntrances", "CarnetId", "dbo.Carnets");
            DropColumn("dbo.Visitors", "ReturnCarnet");
            DropColumn("dbo.VisitorEntrances", "CarnetId");
        }
    }
}
