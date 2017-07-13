namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoidenstudentsectiontable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSections", "Section_Id", "dbo.Sections");
            DropIndex("dbo.StudentSections", new[] { "Section_Id" });
            RenameColumn(table: "dbo.StudentSections", name: "Section_Id", newName: "SectionId");
            RenameColumn(table: "dbo.StudentSections", name: "ApplicationUser_Id", newName: "StudentId");
            RenameIndex(table: "dbo.StudentSections", name: "IX_ApplicationUser_Id", newName: "IX_StudentId");
            AlterColumn("dbo.StudentSections", "SectionId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentSections", "SectionId");
            AddForeignKey("dbo.StudentSections", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSections", "SectionId", "dbo.Sections");
            DropIndex("dbo.StudentSections", new[] { "SectionId" });
            AlterColumn("dbo.StudentSections", "SectionId", c => c.Int());
            RenameIndex(table: "dbo.StudentSections", name: "IX_StudentId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.StudentSections", name: "StudentId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.StudentSections", name: "SectionId", newName: "Section_Id");
            CreateIndex("dbo.StudentSections", "Section_Id");
            AddForeignKey("dbo.StudentSections", "Section_Id", "dbo.Sections", "Id");
        }
    }
}
