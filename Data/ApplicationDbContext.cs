using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;
using static OpDoc_Manager.Models.Forklift;

namespace OpDoc_Manager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<OperatorInformation> OperatorInformation { get; set; }
        public DbSet<LeaseInformation> LeaseInformation { get; set; }
        public DbSet<UserManualInformation> UserManualInformation { get; set; }
        public DbSet<TechnicalInformation> TechnicalInformation { get; set; }

        public DbSet<ModelInformation> ForkliftModels { get; set; }
        public DbSet<Engine> Engines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Forklift>().HasOne(f => f.Operator).WithOne().HasForeignKey<OperatorInformation>(o => o.Id);
            builder.Entity<OperatorInformation>().HasOne(f => f.LeaseInformation).WithOne().HasForeignKey<LeaseInformation>(li => li.Id).IsRequired(false);
            builder.Entity<Forklift>().HasOne(f => f.UserManual).WithOne().HasForeignKey<UserManualInformation>(mi => mi.Id);


            builder.Entity<ElectricEngine>().ToTable("ElectricEngines");
            builder.Entity<InternalCombustionEngine>().ToTable("ICEngine");
            builder.Entity<ModelInformation>().HasOne(m => m.Engine).WithOne().HasForeignKey<ModelInformation>(mi => mi.EngineId);


            builder.Entity<Forklift>().HasOne(f => f.Technical).WithOne().HasForeignKey<TechnicalInformation>(ti => ti.Id);
            builder.Entity<TechnicalInformation>().HasOne(ti => ti.Model).WithMany().HasForeignKey(ti => ti.ModelId);
        }
    }
}