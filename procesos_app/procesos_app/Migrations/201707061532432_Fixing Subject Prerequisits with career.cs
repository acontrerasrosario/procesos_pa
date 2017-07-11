namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingSubjectPrerequisitswithcareer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectCareers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectCareers", "Career_Id", "dbo.Careers");
            DropForeignKey("dbo.Subjects", "Subject1_Id", "dbo.Subjects");
            DropIndex("dbo.Subjects", new[] { "Subject1_Id" });
            DropIndex("dbo.SubjectCareers", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectCareers", new[] { "Career_Id" });
            DropColumn("dbo.Subjects", "PreRequisitCredits");
            DropColumn("dbo.Subjects", "Subject1_Id");
            DropTable("dbo.SubjectCareers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectCareers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Career_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Career_Id });
            
            AddColumn("dbo.Subjects", "Subject1_Id", c => c.Int());
            AddColumn("dbo.Subjects", "PreRequisitCredits", c => c.Int(nullable: false));
            CreateIndex("dbo.SubjectCareers", "Career_Id");
            CreateIndex("dbo.SubjectCareers", "Subject_Id");
            CreateIndex("dbo.Subjects", "Subject1_Id");
            AddForeignKey("dbo.Subjects", "Subject1_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.SubjectCareers", "Career_Id", "dbo.Careers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectCareers", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
