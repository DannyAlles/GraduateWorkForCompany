namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FIO = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Seria = c.String(nullable: false, maxLength: 4),
                        Number = c.String(nullable: false, maxLength: 10),
                        BirthAt = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Clients");
        }
    }
}
