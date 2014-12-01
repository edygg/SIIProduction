namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIdCards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CNE",
                c => new
                    {
                        IDENTIDAD = c.String(nullable: false, maxLength: 50, unicode: false),
                        PNOMBRE = c.String(maxLength: 50, unicode: false),
                        SNOMBRE = c.String(maxLength: 50, unicode: false),
                        PAPELLIDO = c.String(maxLength: 50, unicode: false),
                        SAPELLIDO = c.String(maxLength: 50, unicode: false),
                        SEXO = c.String(maxLength: 50, unicode: false),
                        DEPTO = c.String(maxLength: 50, unicode: false),
                        MUNI = c.String(maxLength: 50, unicode: false),
                        POBLADO = c.String(maxLength: 50, unicode: false),
                        AREA = c.String(maxLength: 50, unicode: false),
                        SECTOR = c.String(maxLength: 50, unicode: false),
                        MESA = c.String(maxLength: 50, unicode: false),
                        LINEA = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDENTIDAD);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CNE");
        }
    }
}
