namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listofclassrooms : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ClassRooms", new[] { "Builder_Id" });
            RenameColumn(table: "dbo.Builders", name: "Builder_Id", newName: "ClassRoom_Id");
            CreateIndex("dbo.Builders", "ClassRoom_Id");
            DropColumn("dbo.ClassRooms", "Builder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassRooms", "Builder_Id", c => c.Int());
            DropIndex("dbo.Builders", new[] { "ClassRoom_Id" });
            RenameColumn(table: "dbo.Builders", name: "ClassRoom_Id", newName: "Builder_Id");
            CreateIndex("dbo.ClassRooms", "Builder_Id");
        }
    }
}
