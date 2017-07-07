namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingforeignkey_teacersection3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "Subject_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "Subject_Id");
        }
    }
}
