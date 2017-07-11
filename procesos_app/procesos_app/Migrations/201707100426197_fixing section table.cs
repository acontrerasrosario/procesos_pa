namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingsectiontable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sections", "Trimester_Id", "dbo.Trimesters");
            DropIndex("dbo.Sections", new[] { "Trimester_Id" });
            RenameColumn(table: "dbo.Sections", name: "Trimester_Id", newName: "TrimesterId");
            AlterColumn("dbo.Sections", "TrimesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sections", "TrimesterId");
            AddForeignKey("dbo.Sections", "TrimesterId", "dbo.Trimesters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "TrimesterId", "dbo.Trimesters");
            DropIndex("dbo.Sections", new[] { "TrimesterId" });
            AlterColumn("dbo.Sections", "TrimesterId", c => c.Int());
            RenameColumn(table: "dbo.Sections", name: "TrimesterId", newName: "Trimester_Id");
            CreateIndex("dbo.Sections", "Trimester_Id");
            AddForeignKey("dbo.Sections", "Trimester_Id", "dbo.Trimesters", "Id");
        }
    }
}
