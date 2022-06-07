namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentUpdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Appointments", "EndsAt");
            DropColumn("public.Appointments", "Type");
            DropColumn("public.Appointments", "Status");
        }
        
        public override void Down()
        {
            AddColumn("public.Appointments", "Status", c => c.Int(nullable: false));
            AddColumn("public.Appointments", "Type", c => c.Int(nullable: false));
            AddColumn("public.Appointments", "EndsAt", c => c.DateTime(nullable: false));
        }
    }
}
