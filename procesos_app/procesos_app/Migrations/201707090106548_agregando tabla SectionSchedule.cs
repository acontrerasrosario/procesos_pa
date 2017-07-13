namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandotablaSectionSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SectionSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SectionSchedules", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.SectionSchedules", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.SectionSchedules", new[] { "ScheduleId" });
            DropIndex("dbo.SectionSchedules", new[] { "SectionId" });
            DropTable("dbo.SectionSchedules");
        }
    }
}
