namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDoctorTimetable : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Appointments", "Description");
        }
        
        public override void Down()
        {
            AddColumn("public.Appointments", "Description", c => c.String(maxLength: 1000));
        }
    }
}
