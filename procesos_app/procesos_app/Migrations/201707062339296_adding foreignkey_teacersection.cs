namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingforeignkey_teacersection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherSections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TeacherSections", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.TeacherSections", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.TeacherSections", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.TeacherSections", "ApplicationUser_Id1");
            AddForeignKey("dbo.TeacherSections", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSections", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.TeacherSections", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.TeacherSections", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.TeacherSections", "ApplicationUser_Id1");
            CreateIndex("dbo.TeacherSections", "ApplicationUser_Id");
            AddForeignKey("dbo.TeacherSections", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
