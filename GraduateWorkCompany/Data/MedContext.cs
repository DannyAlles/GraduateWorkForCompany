using System.Data.Entity;
using GraduateWorkCompany.Data.Models;

namespace GraduateWorkCompany.Data
{
    public class MedContext : DbContext
    {
        public MedContext() : base("Default")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MedContext, GraduateWorkCompany.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MedContext>(null);
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Cab> Cabs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Registry> Registries { get; set; }
    }
}
