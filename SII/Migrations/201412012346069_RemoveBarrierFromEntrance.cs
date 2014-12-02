namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBarrierFromEntrance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entrances", "BarrierId", "dbo.barreras");
            DropIndex("dbo.Entrances", new[] { "BarrierId" });
            RenameColumn(table: "dbo.Entrances", name: "BarrierId", newName: "Barrier_Id");
            AddForeignKey("dbo.Entrances", "Barrier_Id", "dbo.barreras", "Id");
            CreateIndex("dbo.Entrances", "Barrier_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Entrances", new[] { "Barrier_Id" });
            DropForeignKey("dbo.Entrances", "Barrier_Id", "dbo.barreras");
            RenameColumn(table: "dbo.Entrances", name: "Barrier_Id", newName: "BarrierId");
            CreateIndex("dbo.Entrances", "BarrierId");
            AddForeignKey("dbo.Entrances", "BarrierId", "dbo.barreras", "Id", cascadeDelete: true);
        }
    }
}
