namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampusModelValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campus", "Code", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Campus", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Campus", "Details", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campus", "Details", c => c.String());
            AlterColumn("dbo.Campus", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Campus", "Code", c => c.String(nullable: false));
        }
    }
}
