namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Section_Id);
            
            AddColumn("dbo.Subjects", "Areas_Id", c => c.Int());
            CreateIndex("dbo.Subjects", "Areas_Id");
            AddForeignKey("dbo.Subjects", "Areas_Id", "dbo.Areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSections", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.TeacherSections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subjects", "Areas_Id", "dbo.Areas");
            DropIndex("dbo.TeacherSections", new[] { "Section_Id" });
            DropIndex("dbo.TeacherSections", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Subjects", new[] { "Areas_Id" });
            DropColumn("dbo.Subjects", "Areas_Id");
            DropTable("dbo.TeacherSections");
        }
    }
}
