namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandotabladerevisionyopciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Opciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Revisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        SectionId = c.Int(nullable: false),
                        SolicitudStudiante = c.Boolean(nullable: false),
                        AreaId = c.Int(nullable: false),
                        SolicidudArea = c.Int(nullable: false),
                        Cambio = c.Boolean(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                        Finished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .ForeignKey("dbo.AspNetUsers", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.SectionId)
                .Index(t => t.AreaId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revisions", "TeacherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Revisions", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Revisions", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Revisions", "AreaId", "dbo.Areas");
            DropIndex("dbo.Revisions", new[] { "TeacherId" });
            DropIndex("dbo.Revisions", new[] { "AreaId" });
            DropIndex("dbo.Revisions", new[] { "SectionId" });
            DropIndex("dbo.Revisions", new[] { "StudentId" });
            DropTable("dbo.Revisions");
            DropTable("dbo.Opciones");
        }
    }
}
