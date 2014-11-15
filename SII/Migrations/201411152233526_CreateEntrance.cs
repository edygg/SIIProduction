namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntrance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entrances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitId = c.Int(nullable: false),
                        BarrierId = c.Int(nullable: false),
                        State = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(storeType: "datetime2"),
                        Dropped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entrances");
        }
    }
}
