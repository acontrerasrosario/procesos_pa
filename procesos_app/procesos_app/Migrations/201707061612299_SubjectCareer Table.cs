namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectCareerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectCareers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Trimestre = c.Int(nullable: false),
                        SubjectPreRequisits = c.Int(nullable: false),
                        PreRequisitCredits = c.Int(nullable: false),
                        Career_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Careers", t => t.Career_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Career_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectCareers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectCareers", "Career_Id", "dbo.Careers");
            DropIndex("dbo.SubjectCareers", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectCareers", new[] { "Career_Id" });
            DropTable("dbo.SubjectCareers");
        }
    }
}
