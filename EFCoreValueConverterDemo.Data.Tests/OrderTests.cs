using EFCoreValueConverterDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace EFCoreValueConverterDemo.Data.Tests
{
    public class OrderTests
    {
        private DbContextOptions ContextOptions { get; }

        public OrderTests()
        {
            ContextOptions = new DbContextOptionsBuilder()
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=EFCoreValueConverterDemoDB;Trusted_Connection=True")
                .Options;
        }

        [SetUp]
        public void Setup()
        {
            using (var dbContext = new DemoDbContext(ContextOptions))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }
        }

        private static List<(int Quantity, string Description)> OrderItems => new List<(int, string)>()
        {
            (1, "Partridge in a Pear Tree"),
            (2, "Turtle Doves"),
            (3, "French Hens"),
            (4, "Calling Birds"),
            (5, "Gold Rings"),
            (6, "Geese A-Laying"),
            (7, "Swans A-Swimming"),
            (8, "Maids A-Milking"),
            (9, "Ladies Dancing"),
            (10, "Lords A-Leaping"),
            (11, "Pipers Piping"),
            (12, "Drummers Drumming")
        };

        private IEnumerable<Order> GetOrders()
        {
            for (int i = 1; i <= 12; i++)
            {
                var christmasDay = new DateTime(2020, 12, 25);
                yield return new Order()
                {
                    CreatedDate = christmasDay.AddDays(i - 12),
                    CompletedDate = christmasDay.AddDays(i - 12),
                    OrderItems = OrderItems.Where(x => x.Quantity <= i).Select(x => new OrderItem()
                    {
                        OrderItemID = Guid.NewGuid(),
                        Description = x.Description,
                        Quantity = x.Quantity
                    }).ToList()
                };
            }
        }

        [Test]
        public void DoesConvertOrderItems()
        {
            using (var dbContext = new DemoDbContext(ContextOptions))
            {
                // No exceptions thrown when serializing to DB
                Assert.DoesNotThrow(() =>
                {
                    dbContext.AddRange(GetOrders());
                    dbContext.SaveChanges();
                });

                var orders = dbContext.Orders.AsEnumerable();

                Assert.IsTrue(orders.All(x => x.OrderID != Guid.Empty));
                Assert.IsTrue(orders.All(x => x.OrderItems.Count() > 0));
            }
        }
    }
}