namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGuardDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuardDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CampusId = c.Int(nullable: false),
                        TypeEntrance = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(storeType: "datetime2"),
                        Dropped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .Index(t => t.CampusId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GuardDetails", new[] { "CampusId" });
            DropForeignKey("dbo.GuardDetails", "CampusId", "dbo.Campus");
            DropTable("dbo.GuardDetails");
        }
    }
}
