namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCab : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Cabs", "Description", c => c.String(maxLength: 255));
            DropColumn("public.Cabs", "Descriptiom");
        }
        
        public override void Down()
        {
            AddColumn("public.Cabs", "Descriptiom", c => c.String(maxLength: 255));
            DropColumn("public.Cabs", "Description");
        }
    }
}
