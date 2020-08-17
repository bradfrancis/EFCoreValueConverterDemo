using EFCoreValueConverterDemo.Data.Entities;
using EFCoreValueConverterDemo.Data.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreValueConverterDemo.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order");

            builder
                .HasKey(x => x.OrderID)
                .HasName("PK_Order_OrderID");

            builder
                .Property(x => x.OrderID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(x => x.OrderItems)
                .HasConversion(new JsonValueConverter<OrderItemCollection>());
        }
    }
}
