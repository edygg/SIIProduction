namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUniqueIndexCarnet : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Carnets", new string[] { "Number", "CampusId" }, true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Carnets", new string[] { "Number", "CampusId" });
        }
    }
}
