namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingteachersection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherSections", "Section_Id", "dbo.Sections");
            DropIndex("dbo.TeacherSections", new[] { "Section_Id" });
            RenameColumn(table: "dbo.TeacherSections", name: "Section_Id", newName: "SectionId");
            RenameColumn(table: "dbo.TeacherSections", name: "ApplicationUser_Id", newName: "TeacherId");
            RenameIndex(table: "dbo.TeacherSections", name: "IX_ApplicationUser_Id", newName: "IX_TeacherId");
            AlterColumn("dbo.TeacherSections", "SectionId", c => c.Int(nullable: false));
            CreateIndex("dbo.TeacherSections", "SectionId");
            AddForeignKey("dbo.TeacherSections", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSections", "SectionId", "dbo.Sections");
            DropIndex("dbo.TeacherSections", new[] { "SectionId" });
            AlterColumn("dbo.TeacherSections", "SectionId", c => c.Int());
            RenameIndex(table: "dbo.TeacherSections", name: "IX_TeacherId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.TeacherSections", name: "TeacherId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.TeacherSections", name: "SectionId", newName: "Section_Id");
            CreateIndex("dbo.TeacherSections", "Section_Id");
            AddForeignKey("dbo.TeacherSections", "Section_Id", "dbo.Sections", "Id");
        }
    }
}
