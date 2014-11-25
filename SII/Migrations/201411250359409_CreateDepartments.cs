namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            DropTable("dbo.Departments");
        }
    }
}
