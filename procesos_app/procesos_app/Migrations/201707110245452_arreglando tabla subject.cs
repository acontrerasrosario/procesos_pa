namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglandotablasubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Areas_Id", "dbo.Areas");
            DropIndex("dbo.Subjects", new[] { "Areas_Id" });
            RenameColumn(table: "dbo.Subjects", name: "Areas_Id", newName: "AreasId");
            AlterColumn("dbo.Subjects", "AreasId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "AreasId");
            AddForeignKey("dbo.Subjects", "AreasId", "dbo.Areas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "AreasId", "dbo.Areas");
            DropIndex("dbo.Subjects", new[] { "AreasId" });
            AlterColumn("dbo.Subjects", "AreasId", c => c.Int());
            RenameColumn(table: "dbo.Subjects", name: "AreasId", newName: "Areas_Id");
            CreateIndex("dbo.Subjects", "Areas_Id");
            AddForeignKey("dbo.Subjects", "Areas_Id", "dbo.Areas", "Id");
        }
    }
}
