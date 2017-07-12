namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandodetallederevision : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleRevisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RevisionId = c.Int(nullable: false),
                        FinalScore = c.Double(nullable: false),
                        FinalScoreUpdated = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Revisions", t => t.RevisionId, cascadeDelete: true)
                .Index(t => t.RevisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleRevisions", "RevisionId", "dbo.Revisions");
            DropIndex("dbo.DetalleRevisions", new[] { "RevisionId" });
            DropTable("dbo.DetalleRevisions");
        }
    }
}
