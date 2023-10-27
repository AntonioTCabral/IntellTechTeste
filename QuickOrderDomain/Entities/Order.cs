using Microsoft.EntityFrameworkCore;
using QuickOrderDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace QuickOrderDomain.Entities
{
    [Table("Orders")] // Define o nome da tabela
    public class Order
    {
        [Key] // Define a chave primária
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime OrderedAt { get; private set; } = DateTime.Now;
        public List<OrderItem> Items { get; private set; } = new();
        public decimal Total => Items.Sum(item => item.Price);
        public OrderStatus Status { get; set; }

        public void AddItem(DisheItem menuItem, int quantity)
        {
            Items.Add(new OrderItem(menuItem, quantity));
        }

        public static Order CreateNewOrder()
        {
            return new Order();
        }

        public static Order GetOrderById(Guid orderId, OrderDbContext dbContext)
        {
            return dbContext.Orders.FirstOrDefault(order => order.Id == orderId);
        }

        public static List<Order> GetAllOrders(OrderDbContext dbContext)
        {
            return dbContext.Orders.ToList();
        }

        public void Update(Order updatedOrder)
        {
            OrderedAt = updatedOrder.OrderedAt;
            Status = updatedOrder.Status;
            // Atualize os itens conforme necessário
        }

        public static void DeleteOrder(Guid orderId, OrderDbContext dbContext)
        {
            var order = dbContext.Orders.FirstOrDefault(order => order.Id == orderId);
            if (order != null)
            {
                dbContext.Orders.Remove(order);
                dbContext.SaveChanges();
            }
        }
    }

    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
    }
}
