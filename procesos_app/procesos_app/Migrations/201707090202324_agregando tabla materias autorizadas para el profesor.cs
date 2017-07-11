namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandotablamateriasautorizadasparaelprofesor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfesorAutorizacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfesorId = c.String(maxLength: 128),
                        MateriaId = c.Int(nullable: false),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ProfesorId)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.ProfesorId)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfesorAutorizacions", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ProfesorAutorizacions", "ProfesorId", "dbo.AspNetUsers");
            DropIndex("dbo.ProfesorAutorizacions", new[] { "Subject_Id" });
            DropIndex("dbo.ProfesorAutorizacions", new[] { "ProfesorId" });
            DropTable("dbo.ProfesorAutorizacions");
        }
    }
}
