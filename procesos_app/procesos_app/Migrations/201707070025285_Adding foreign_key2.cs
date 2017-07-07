namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingforeign_key2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCareers", "Career_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCareers", "Career_Id", c => c.String());
        }
    }
}
