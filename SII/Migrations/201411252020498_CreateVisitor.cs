namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVisitor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identity = c.String(nullable: false, maxLength: 15),
                        IdentityType = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 100),
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
            DropTable("dbo.Visitors");
        }
    }
}
