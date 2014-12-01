namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeingKeysVisitorEntrances : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitorEntrances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitorId = c.Int(nullable: false),
                        BarrierId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Carnet = c.Int(nullable: false),
                        ReturnCarnet = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(storeType: "datetime2"),
                        Dropped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.barreras", t => t.BarrierId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.VisitorId, cascadeDelete: true)
                .Index(t => t.BarrierId)
                .Index(t => t.DepartmentId)
                .Index(t => t.VisitorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.VisitorEntrances", new[] { "VisitorId" });
            DropIndex("dbo.VisitorEntrances", new[] { "DepartmentId" });
            DropIndex("dbo.VisitorEntrances", new[] { "BarrierId" });
            DropForeignKey("dbo.VisitorEntrances", "VisitorId", "dbo.Visitors");
            DropForeignKey("dbo.VisitorEntrances", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.VisitorEntrances", "BarrierId", "dbo.barreras");
            DropTable("dbo.VisitorEntrances");
        }
    }
}
