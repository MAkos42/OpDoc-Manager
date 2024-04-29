using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Model.Entity;

namespace OpDoc_Manager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Forklift> Forklifts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Forklift>().OwnsOne(e => e.General);
        }
    }
}