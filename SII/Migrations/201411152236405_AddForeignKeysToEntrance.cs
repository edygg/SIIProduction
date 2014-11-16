namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysToEntrance : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Entrances", "VisitId", "dbo.Visits", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Entrances", "BarrierId", "dbo.barreras", "Id", cascadeDelete: false);
            CreateIndex("dbo.Entrances", "VisitId");
            CreateIndex("dbo.Entrances", "BarrierId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Entrances", new[] { "BarrierId" });
            DropIndex("dbo.Entrances", new[] { "VisitId" });
            DropForeignKey("dbo.Entrances", "BarrierId", "dbo.barreras");
            DropForeignKey("dbo.Entrances", "VisitId", "dbo.Visits");
        }
    }
}
