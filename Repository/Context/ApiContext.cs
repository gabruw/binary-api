using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Config;

namespace Repository.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DiffLeft>();
            modelBuilder.Ignore<DiffRight>();

            modelBuilder.ApplyConfiguration(new DiffLeftConfiguration());
            modelBuilder.ApplyConfiguration(new DiffRightConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DiffLeft> DiffLeft { get; set; }
        public DbSet<DiffRight> DiffRight { get; set; }
    }
}
