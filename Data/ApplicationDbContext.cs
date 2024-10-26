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
        public DbSet<AdapterInformation> AdapterInformation { get; set; }

        public DbSet<AdapterRecord> Adapters { get; set; }

        public DbSet<ModelInformation> ForkliftModels { get; set; }
        public DbSet<Engine> Engines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Forklift>().OwnsOne(f => f.General, general =>
            {
                general.HasOne(g => g.Model).WithMany().HasForeignKey(g => g.ModelId);
            });

            builder.Entity<Forklift>().HasOne(f => f.Operator).WithOne().HasForeignKey<OperatorInformation>(o => o.Id);
            builder.Entity<OperatorInformation>().HasOne(f => f.LeaseInformation).WithOne().HasForeignKey<LeaseInformation>(li => li.Id).IsRequired(false);
            builder.Entity<Forklift>().HasOne(f => f.UserManual).WithOne().HasForeignKey<UserManualInformation>(mi => mi.Id);
            builder.Entity<Forklift>().HasOne(f => f.Adapter).WithOne().HasForeignKey<AdapterInformation>(ai => ai.Id);
            builder.Entity<AdapterInformation>().HasMany(ai => ai.AdapterList).WithOne().HasForeignKey(ar => ar.AdapterId);

            builder.Entity<ElectricEngine>().ToTable("ElectricEngines");
            builder.Entity<InternalCombustionEngine>().ToTable("ICEngine");
            builder.Entity<ModelInformation>().HasOne(m => m.Engine).WithOne().HasForeignKey<ModelInformation>(mi => mi.EngineId);

        }
    }
}