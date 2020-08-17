using EFCoreValueConverterDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreValueConverterDemo.Data
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options)
            : base (options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder
                .Entity<Order>()
                .Property(x => x.CompletedDate)
                .HasColumnType("DATETIME2(5)");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
