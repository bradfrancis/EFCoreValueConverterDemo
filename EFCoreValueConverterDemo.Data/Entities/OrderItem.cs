using System;

namespace EFCoreValueConverterDemo.Data.Entities
{
    public class OrderItem
    {
        public Guid OrderItemID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
