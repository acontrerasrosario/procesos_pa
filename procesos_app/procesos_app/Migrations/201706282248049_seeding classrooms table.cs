namespace procesos_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingclassroomstable : DbMigration
    {
        public override void Up()
        {
            // adding GC ClassRooms
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('202',3)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('203',3)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('204',3)");
            // adding AJ ClassRooms
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('201',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('202',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('301',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('302',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('303',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('304',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('401',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('402',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('403',8)");
            Sql("INSERT INTO ClassRooms(Name,Builder_Id) VALUES('404',8)");
            
            // adding careers
            Sql("INSERT INTO Careers(Name,NoTrimester,NoCredito,NoSubjetcs,Area_Id) VALUES('Ingenieria de Software',21,248,56,4)");
            Sql("INSERT INTO Careers(Name,NoTrimester,NoCredito,NoSubjetcs,Area_Id) VALUES('Ingenieria de Sistemas',21,252,63,4)");

            


        }
        
        public override void Down()
        {
        }
    }
}
