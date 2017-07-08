namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codigoenmateria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Codigo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Codigo");
        }
    }
}
