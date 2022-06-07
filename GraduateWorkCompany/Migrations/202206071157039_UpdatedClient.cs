namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Clients", "OMS", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("public.Clients", "OMS");
        }
    }
}
