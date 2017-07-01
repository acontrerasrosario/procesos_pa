namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cedulachartostring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Cedula", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Cedula");
        }
    }
}
