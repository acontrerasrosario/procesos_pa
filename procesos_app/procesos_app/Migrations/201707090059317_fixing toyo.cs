namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingtoyo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SectionSchedules", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.SectionSchedules", "Schedule_Id", "dbo.Schedules");
            DropIndex("dbo.SectionSchedules", new[] { "Section_Id" });
            DropIndex("dbo.SectionSchedules", new[] { "Schedule_Id" });
            DropTable("dbo.SectionSchedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SectionSchedules",
                c => new
                    {
                        Section_Id = c.Int(nullable: false),
                        Schedule_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Section_Id, t.Schedule_Id });
            
            CreateIndex("dbo.SectionSchedules", "Schedule_Id");
            CreateIndex("dbo.SectionSchedules", "Section_Id");
            AddForeignKey("dbo.SectionSchedules", "Schedule_Id", "dbo.Schedules", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SectionSchedules", "Section_Id", "dbo.Sections", "Id", cascadeDelete: true);
        }
    }
}
