namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingforeignkey_teacersection2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TeacherSections", name: "Section_Id", newName: "Section_Id_Id");
            RenameIndex(table: "dbo.TeacherSections", name: "IX_Section_Id", newName: "IX_Section_Id_Id");
            AddColumn("dbo.TeacherSections", "Section_Id1", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeacherSections", "Section_Id1");
            RenameIndex(table: "dbo.TeacherSections", name: "IX_Section_Id_Id", newName: "IX_Section_Id");
            RenameColumn(table: "dbo.TeacherSections", name: "Section_Id_Id", newName: "Section_Id");
        }
    }
}
