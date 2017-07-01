namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTeacherSectionandStudentSection : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Periods", newName: "Schedules");
            RenameTable(name: "dbo.UserSections", newName: "StudentSections");
            RenameTable(name: "dbo.SectionPeriods", newName: "SectionSchedules");
            RenameColumn(table: "dbo.SectionSchedules", name: "Period_Id", newName: "Schedule_Id");
            RenameIndex(table: "dbo.SectionSchedules", name: "IX_Period_Id", newName: "IX_Schedule_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SectionSchedules", name: "IX_Schedule_Id", newName: "IX_Period_Id");
            RenameColumn(table: "dbo.SectionSchedules", name: "Schedule_Id", newName: "Period_Id");
            RenameTable(name: "dbo.SectionSchedules", newName: "SectionPeriods");
            RenameTable(name: "dbo.StudentSections", newName: "UserSections");
            RenameTable(name: "dbo.Schedules", newName: "Periods");
        }
    }
}
