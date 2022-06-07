namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppointment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Clients", "Login", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("public.Clients", "Password", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("public.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("public.Clients", "Login", c => c.String(nullable: false));
        }
    }
}
