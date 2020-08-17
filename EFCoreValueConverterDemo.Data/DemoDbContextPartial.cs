using EFCoreValueConverterDemo.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EFCoreValueConverterDemo.Data
{
    public partial class DemoDbContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
