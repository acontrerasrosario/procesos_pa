namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexinganduniquefieldId2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "UserName" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AspNetUsers", "UserName");
        }
    }
}
