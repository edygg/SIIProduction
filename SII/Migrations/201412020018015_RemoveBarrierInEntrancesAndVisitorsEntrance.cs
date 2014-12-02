namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBarrierInEntrancesAndVisitorsEntrance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entrances", "Barrier_Id", "dbo.barreras");
            DropForeignKey("dbo.VisitorEntrances", "BarrierId", "dbo.barreras");
            DropIndex("dbo.Entrances", new[] { "Barrier_Id" });
            DropIndex("dbo.VisitorEntrances", new[] { "BarrierId" });
            DropColumn("dbo.Entrances", "Barrier_Id");
            DropColumn("dbo.VisitorEntrances", "BarrierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisitorEntrances", "BarrierId", c => c.Int(nullable: false));
            AddColumn("dbo.Entrances", "Barrier_Id", c => c.Int());
            CreateIndex("dbo.VisitorEntrances", "BarrierId");
            CreateIndex("dbo.Entrances", "Barrier_Id");
            AddForeignKey("dbo.VisitorEntrances", "BarrierId", "dbo.barreras", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entrances", "Barrier_Id", "dbo.barreras", "Id");
        }
    }
}
