namespace SII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime2ColumnsBaseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campus", "CreatedAt", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.Campus", "UpdatedAt", c => c.DateTime(storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campus", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Campus", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
