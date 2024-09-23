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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Forklift>().HasOne(f => f.Operator).WithOne().HasForeignKey<Forklift.OperatorInformation>(f => f.Id);
            builder.Entity<Forklift.OperatorInformation>().HasOne(f => f.LeaseInformation).WithOne().HasForeignKey<Forklift.ForkliftLeaseInformation>(f => f.Id).IsRequired(false);
        }
    }
}