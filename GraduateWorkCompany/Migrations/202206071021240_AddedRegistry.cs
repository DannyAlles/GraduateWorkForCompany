namespace GraduateWorkCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRegistry : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.Appointments", name: "Cab_Id", newName: "CabId");
            RenameColumn(table: "public.Appointments", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "public.Appointments", name: "Doctor_Id", newName: "DoctorId");
            RenameIndex(table: "public.Appointments", name: "IX_Client_Id", newName: "IX_ClientId");
            RenameIndex(table: "public.Appointments", name: "IX_Doctor_Id", newName: "IX_DoctorId");
            RenameIndex(table: "public.Appointments", name: "IX_Cab_Id", newName: "IX_CabId");
            CreateTable(
                "public.Registries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Login = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        FIO = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("public.Doctors", "CreataedById", c => c.Guid(nullable: false));
            CreateIndex("public.Doctors", "CreataedById");
            AddForeignKey("public.Doctors", "CreataedById", "public.Registries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.Doctors", "CreataedById", "public.Registries");
            DropIndex("public.Doctors", new[] { "CreataedById" });
            DropColumn("public.Doctors", "CreataedById");
            DropTable("public.Registries");
            RenameIndex(table: "public.Appointments", name: "IX_CabId", newName: "IX_Cab_Id");
            RenameIndex(table: "public.Appointments", name: "IX_DoctorId", newName: "IX_Doctor_Id");
            RenameIndex(table: "public.Appointments", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameColumn(table: "public.Appointments", name: "DoctorId", newName: "Doctor_Id");
            RenameColumn(table: "public.Appointments", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "public.Appointments", name: "CabId", newName: "Cab_Id");
        }
    }
}
