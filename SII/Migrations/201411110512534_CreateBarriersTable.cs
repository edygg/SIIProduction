namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBarriersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.barreras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        barrera = c.String(nullable: false, maxLength: 16),
                        ip = c.String(nullable: false, maxLength: 15),
                        puerto = c.Int(nullable: false),
                        activo = c.Boolean(nullable: false),
                        CampusId = c.Int(nullable: false),
                        AutorizaDocentes = c.Boolean(nullable: false),
                        AutorizaAdministrativos = c.Boolean(nullable: false),
                        AutorizaAlumnos = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(storeType: "datetime2"),
                        Dropped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            CreateIndex("dbo.barreras", "ip", true);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.barreras");
        }
    }
}
