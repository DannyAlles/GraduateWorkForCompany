namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Doctors", "CabId", c => c.Guid(nullable: false));
            CreateIndex("public.Doctors", "CabId");
            AddForeignKey("public.Doctors", "CabId", "public.Cabs", "Id", cascadeDelete: true);
            DropColumn("public.Doctors", "Weekdays");
        }
        
        public override void Down()
        {
            AddColumn("public.Doctors", "Weekdays", c => c.Int(nullable: false));
            DropForeignKey("public.Doctors", "CabId", "public.Cabs");
            DropIndex("public.Doctors", new[] { "CabId" });
            DropColumn("public.Doctors", "CabId");
        }
    }
}
