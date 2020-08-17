using System;
using System.Collections.Generic;

namespace EFCoreValueConverterDemo.Data.Entities
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public OrderItemCollection OrderItems { get; set; }
    }
}
