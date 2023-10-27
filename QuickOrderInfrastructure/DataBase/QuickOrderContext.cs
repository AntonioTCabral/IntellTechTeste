using Microsoft.EntityFrameworkCore;
using QuickOrderDomain.Entities;

namespace QuickOrderInfrastructure.DataBase;

public class QuickOrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; } 
    
    public QuickOrderContext(DbContextOptions<QuickOrderContext> options) : base(options) { }
}