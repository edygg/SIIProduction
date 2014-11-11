namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToBarriers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.barreras", "descripcion", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.barreras", "descripcion");
        }
    }
}
