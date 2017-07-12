namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglandomotivodetablarevision : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Revisions", "Motivo", c => c.String());
            DropColumn("dbo.DetalleRevisions", "Motivo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleRevisions", "Motivo", c => c.String());
            DropColumn("dbo.Revisions", "Motivo");
        }
    }
}
