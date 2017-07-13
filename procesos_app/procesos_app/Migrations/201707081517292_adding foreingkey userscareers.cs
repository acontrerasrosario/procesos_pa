namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingforeingkeyuserscareers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCareers", "Career_Id", "dbo.Careers");
            DropForeignKey("dbo.UserCareers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserCareers", new[] { "Career_Id" });
            DropIndex("dbo.UserCareers", new[] { "User_Id" });
            AddColumn("dbo.UserCareers", "Career_Id1", c => c.Int());
            AddColumn("dbo.UserCareers", "User_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserCareers", "Career_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserCareers", "User_Id", c => c.String());
            CreateIndex("dbo.UserCareers", "Career_Id1");
            CreateIndex("dbo.UserCareers", "User_Id1");
            AddForeignKey("dbo.UserCareers", "Career_Id1", "dbo.Careers", "Id");
            AddForeignKey("dbo.UserCareers", "User_Id1", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserCareers", "User_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCareers", "Career_Id1", "dbo.Careers");
            DropIndex("dbo.UserCareers", new[] { "User_Id1" });
            DropIndex("dbo.UserCareers", new[] { "Career_Id1" });
            AlterColumn("dbo.UserCareers", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserCareers", "Career_Id", c => c.Int());
            DropColumn("dbo.UserCareers", "User_Id1");
            DropColumn("dbo.UserCareers", "Career_Id1");
            CreateIndex("dbo.UserCareers", "User_Id");
            CreateIndex("dbo.UserCareers", "Career_Id");
            AddForeignKey("dbo.UserCareers", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserCareers", "Career_Id", "dbo.Careers", "Id");
        }
    }
}
