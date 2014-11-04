namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueIndexCodeCampus : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Campus", "Code", true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Campus", "Code");
        }
    }
}
