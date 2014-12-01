namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityTypeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitors", "IdentityType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "IdentityType", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
