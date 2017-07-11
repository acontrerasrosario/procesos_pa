namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglando : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sections", name: "ClassRoom_Id1", newName: "ClassRoomId");
            RenameIndex(table: "dbo.Sections", name: "IX_ClassRoom_Id1", newName: "IX_ClassRoomId");
            DropColumn("dbo.Sections", "ClassRoom_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sections", "ClassRoom_Id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Sections", name: "IX_ClassRoomId", newName: "IX_ClassRoom_Id1");
            RenameColumn(table: "dbo.Sections", name: "ClassRoomId", newName: "ClassRoom_Id1");
        }
    }
}
