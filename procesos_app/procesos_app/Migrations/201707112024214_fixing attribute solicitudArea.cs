namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingattributesolicitudArea : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Revisions", "SolicidudArea", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Revisions", "SolicidudArea", c => c.Int(nullable: false));
        }
    }
}
