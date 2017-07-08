namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingforeign_key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCareers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserCareers", new[] { "User_Id" });
            AddColumn("dbo.UserCareers", "User_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserCareers", "User_Id", c => c.String());
            CreateIndex("dbo.UserCareers", "User_Id1");
            AddForeignKey("dbo.UserCareers", "User_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCareers", "User_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.UserCareers", new[] { "User_Id1" });
            AlterColumn("dbo.UserCareers", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.UserCareers", "User_Id1");
            CreateIndex("dbo.UserCareers", "User_Id");
            AddForeignKey("dbo.UserCareers", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
