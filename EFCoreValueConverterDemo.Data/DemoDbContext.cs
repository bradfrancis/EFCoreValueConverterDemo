using EFCoreValueConverterDemo.Data.Configurations;
using EFCoreValueConverterDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreValueConverterDemo.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options)
            : base (options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
