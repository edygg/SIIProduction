namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipCampusBarriers : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.barreras", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
            CreateIndex("dbo.barreras", "CampusId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.barreras", new[] { "CampusId" });
            DropForeignKey("dbo.barreras", "CampusId", "dbo.Campus");
        }
    }
}
