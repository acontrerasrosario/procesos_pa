namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingforeignkeyofareainusers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas");
            DropIndex("dbo.AspNetUsers", new[] { "AreaId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "AreaId", newName: "Area_Id");
            AlterColumn("dbo.AspNetUsers", "Area_Id", c => c.Int(nullable:true));
            CreateIndex("dbo.AspNetUsers", "Area_Id");
            AddForeignKey("dbo.AspNetUsers", "Area_Id", "dbo.Areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Area_Id", "dbo.Areas");
            DropIndex("dbo.AspNetUsers", new[] { "Area_Id" });
            AlterColumn("dbo.AspNetUsers", "Area_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "Area_Id", newName: "AreaId");
            CreateIndex("dbo.AspNetUsers", "AreaId");
            AddForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
        }
    }
}
