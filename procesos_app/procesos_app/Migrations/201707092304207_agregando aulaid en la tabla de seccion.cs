namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoaulaidenlatabladeseccion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sections", "ClassRoom_Id", "dbo.ClassRooms");
            DropIndex("dbo.Sections", new[] { "ClassRoom_Id" });
            DropColumn("dbo.Sections", "ClassRoom_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sections", "ClassRoom_Id", c => c.Int());
            CreateIndex("dbo.Sections", "ClassRoom_Id");
            AddForeignKey("dbo.Sections", "ClassRoom_Id", "dbo.ClassRooms", "Id");
        }
    }
}
