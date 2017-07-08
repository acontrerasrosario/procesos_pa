namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedingdatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Builders", "NickName", c => c.String());
            DropColumn("dbo.AspNetUsers", "JoinDate");
            DropColumn("dbo.AspNetUsers", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Builders", "NickName");
        }
    }
}
