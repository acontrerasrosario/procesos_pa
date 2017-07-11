namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificandoprofesorautorizacions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfesorAutorizacions", "ProfesorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProfesorAutorizacions", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.ProfesorAutorizacions", new[] { "ProfesorId" });
            DropIndex("dbo.ProfesorAutorizacions", new[] { "Subject_Id" });
            RenameColumn(table: "dbo.ProfesorAutorizacions", name: "Subject_Id", newName: "SubjectId");
            AlterColumn("dbo.ProfesorAutorizacions", "ProfesorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProfesorAutorizacions", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProfesorAutorizacions", "ProfesorId");
            CreateIndex("dbo.ProfesorAutorizacions", "SubjectId");
            AddForeignKey("dbo.ProfesorAutorizacions", "ProfesorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProfesorAutorizacions", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.ProfesorAutorizacions", "MateriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfesorAutorizacions", "MateriaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProfesorAutorizacions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ProfesorAutorizacions", "ProfesorId", "dbo.AspNetUsers");
            DropIndex("dbo.ProfesorAutorizacions", new[] { "SubjectId" });
            DropIndex("dbo.ProfesorAutorizacions", new[] { "ProfesorId" });
            AlterColumn("dbo.ProfesorAutorizacions", "SubjectId", c => c.Int());
            AlterColumn("dbo.ProfesorAutorizacions", "ProfesorId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.ProfesorAutorizacions", name: "SubjectId", newName: "Subject_Id");
            CreateIndex("dbo.ProfesorAutorizacions", "Subject_Id");
            CreateIndex("dbo.ProfesorAutorizacions", "ProfesorId");
            AddForeignKey("dbo.ProfesorAutorizacions", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.ProfesorAutorizacions", "ProfesorId", "dbo.AspNetUsers", "Id");
        }
    }
}
