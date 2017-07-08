namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingenumsfieldstodifferenttables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sections", "SecType", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentSections", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Genrer", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Tanda", c => c.Int(nullable: false));
            AlterColumn("dbo.UserCareers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCareers", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Tanda", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "Genrer", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.StudentSections", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Sections", "SecType", c => c.String());
        }
    }
}
