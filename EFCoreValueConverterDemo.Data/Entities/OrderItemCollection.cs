using System.Collections.Generic;

namespace EFCoreValueConverterDemo.Data.Entities
{
    public class OrderItemCollection
    {
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
