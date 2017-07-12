namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandomotivodetablarevision : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleRevisions", "Motivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleRevisions", "Motivo");
        }
    }
}
