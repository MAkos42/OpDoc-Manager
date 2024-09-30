using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<Forklift.OperatorInformation> OperatorInformation { get; set; }
        public DbSet<Forklift.ForkliftLeaseInformation> LeaseInformation { get; set; }
        public DbSet<Forklift.UserManualInformation> UserManualInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Forklift>().HasOne(f => f.Operator).WithOne().HasForeignKey<Forklift.OperatorInformation>(o => o.Id);
            builder.Entity<Forklift.OperatorInformation>().HasOne(f => f.LeaseInformation).WithOne().HasForeignKey<Forklift.ForkliftLeaseInformation>(li => li.Id).IsRequired(false);
            builder.Entity<Forklift>().HasOne(f => f.UserManual).WithOne().HasForeignKey<Forklift.UserManualInformation>(mi => mi.Id);
        }
    }
}