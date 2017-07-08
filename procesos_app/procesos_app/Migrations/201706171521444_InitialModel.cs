namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Builders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 120),
                        NoTrimester = c.Int(nullable: false),
                        NoCredito = c.Int(nullable: false),
                        NoSubjetcs = c.Int(nullable: false),
                        Area_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.Area_Id)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        QtyCredits = c.Int(nullable: false),
                        PreRequisitCredits = c.Int(nullable: false),
                        Subject1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject1_Id)
                .Index(t => t.Subject1_Id);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Builder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Builders", t => t.Builder_Id)
                .Index(t => t.Builder_Id);
            
            CreateTable(
                "dbo.Periods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Day = c.Int(nullable: false),
                        Trimester_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trimesters", t => t.Trimester_Id)
                .Index(t => t.Trimester_Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SubjectId = c.Int(nullable: false),
                        SecType = c.String(),
                        ClassRoom_Id = c.Int(),
                        Trimester_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoom_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Trimesters", t => t.Trimester_Id)
                .Index(t => t.SubjectId)
                .Index(t => t.ClassRoom_Id)
                .Index(t => t.Trimester_Id);
            
            CreateTable(
                "dbo.Trimesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Inicio = c.DateTime(nullable: false),
                        Fin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserCareers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtyApprovedQuarter = c.Int(nullable: false),
                        QtyApprovedCredits = c.Int(nullable: false),
                        QtyApprovedSubjects = c.Int(nullable: false),
                        QuarterlyIndex = c.Double(nullable: false),
                        GeneralIndex = c.Double(nullable: false),
                        Status = c.String(nullable: false),
                        Career_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Careers", t => t.Career_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Career_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Id2 = c.Int(nullable: false),
                        InstitutionalEmail = c.String(maxLength: 256),
                        JoinDate = c.DateTime(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Genrer = c.String(nullable: false, maxLength: 25),
                        Tanda = c.String(maxLength: 100),
                        Dispnibilidad = c.String(maxLength: 100),
                        UserType = c.String(maxLength: 100),
                        AreaId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Trimester_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Trimesters", t => t.Trimester_Id)
                .Index(t => t.AreaId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Trimester_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FinalScore = c.Double(nullable: false),
                        Status = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Section_Id);
            
            CreateTable(
                "dbo.SubjectCareers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Career_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Career_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Careers", t => t.Career_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Career_Id);
            
            CreateTable(
                "dbo.SectionPeriods",
                c => new
                    {
                        Section_Id = c.Int(nullable: false),
                        Period_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Section_Id, t.Period_Id })
                .ForeignKey("dbo.Sections", t => t.Section_Id, cascadeDelete: true)
                .ForeignKey("dbo.Periods", t => t.Period_Id, cascadeDelete: true)
                .Index(t => t.Section_Id)
                .Index(t => t.Period_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSections", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.UserSections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCareers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Trimester_Id", "dbo.Trimesters");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.UserCareers", "Career_Id", "dbo.Careers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Periods", "Trimester_Id", "dbo.Trimesters");
            DropForeignKey("dbo.Sections", "Trimester_Id", "dbo.Trimesters");
            DropForeignKey("dbo.Sections", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SectionPeriods", "Period_Id", "dbo.Periods");
            DropForeignKey("dbo.SectionPeriods", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.Sections", "ClassRoom_Id", "dbo.ClassRooms");
            DropForeignKey("dbo.ClassRooms", "Builder_Id", "dbo.Builders");
            DropForeignKey("dbo.Subjects", "Subject1_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectCareers", "Career_Id", "dbo.Careers");
            DropForeignKey("dbo.SubjectCareers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Careers", "Area_Id", "dbo.Areas");
            DropIndex("dbo.SectionPeriods", new[] { "Period_Id" });
            DropIndex("dbo.SectionPeriods", new[] { "Section_Id" });
            DropIndex("dbo.SubjectCareers", new[] { "Career_Id" });
            DropIndex("dbo.SubjectCareers", new[] { "Subject_Id" });
            DropIndex("dbo.UserSections", new[] { "Section_Id" });
            DropIndex("dbo.UserSections", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Trimester_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AreaId" });
            DropIndex("dbo.UserCareers", new[] { "User_Id" });
            DropIndex("dbo.UserCareers", new[] { "Career_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Sections", new[] { "Trimester_Id" });
            DropIndex("dbo.Sections", new[] { "ClassRoom_Id" });
            DropIndex("dbo.Sections", new[] { "SubjectId" });
            DropIndex("dbo.Periods", new[] { "Trimester_Id" });
            DropIndex("dbo.ClassRooms", new[] { "Builder_Id" });
            DropIndex("dbo.Subjects", new[] { "Subject1_Id" });
            DropIndex("dbo.Careers", new[] { "Area_Id" });
            DropTable("dbo.SectionPeriods");
            DropTable("dbo.SubjectCareers");
            DropTable("dbo.UserSections");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserCareers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trimesters");
            DropTable("dbo.Sections");
            DropTable("dbo.Periods");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Subjects");
            DropTable("dbo.Careers");
            DropTable("dbo.Builders");
            DropTable("dbo.Areas");
        }
    }
}
