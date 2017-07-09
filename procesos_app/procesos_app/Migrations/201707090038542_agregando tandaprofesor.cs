namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandotandaprofesor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TandaProfesors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfesorId = c.String(nullable: false, maxLength: 128),
                        TandaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ProfesorId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.TandaId, cascadeDelete: true)
                .Index(t => t.ProfesorId)
                .Index(t => t.TandaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TandaProfesors", "TandaId", "dbo.Schedules");
            DropForeignKey("dbo.TandaProfesors", "ProfesorId", "dbo.AspNetUsers");
            DropIndex("dbo.TandaProfesors", new[] { "TandaId" });
            DropIndex("dbo.TandaProfesors", new[] { "ProfesorId" });
            DropTable("dbo.TandaProfesors");
        }
    }
}
