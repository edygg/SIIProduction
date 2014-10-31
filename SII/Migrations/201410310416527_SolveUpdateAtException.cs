namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolveUpdateAtException : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campus", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campus", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}
