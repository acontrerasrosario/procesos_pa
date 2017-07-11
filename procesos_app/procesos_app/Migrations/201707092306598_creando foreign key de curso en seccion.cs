namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creandoforeignkeydecursoenseccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "ClassRoom_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Sections", "ClassRoom_Id1", c => c.Int());
            CreateIndex("dbo.Sections", "ClassRoom_Id1");
            AddForeignKey("dbo.Sections", "ClassRoom_Id1", "dbo.ClassRooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "ClassRoom_Id1", "dbo.ClassRooms");
            DropIndex("dbo.Sections", new[] { "ClassRoom_Id1" });
            DropColumn("dbo.Sections", "ClassRoom_Id1");
            DropColumn("dbo.Sections", "ClassRoom_Id");
        }
    }
}
