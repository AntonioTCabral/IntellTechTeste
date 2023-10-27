using Microsoft.EntityFrameworkCore;
using QuickOrderDomain.Entities;

namespace QuickOrderInfrastructure.DataBase;

public class QuickOrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<DisheItem> DisheItems { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; } 
    
    public QuickOrderContext(DbContextOptions<QuickOrderContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>().HasKey(x => x.Id);
        modelBuilder.Entity<Order>().Property(x => x.OrderedAt).IsRequired();
        modelBuilder.Entity<Order>().Property(x => x.Status).IsRequired();
        modelBuilder.Entity<Order>().HasMany(x => x.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<OrderItem>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderItem>().Property(x => x.Quantity).IsRequired();
        modelBuilder.Entity<OrderItem>().HasOne(x => x.Dishes).WithMany().OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<DisheItem>().HasKey(x => x.Id);
        modelBuilder.Entity<DisheItem>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.Price).HasColumnType("decimal(18, 2)").IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.Description).IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.ImageUrl).IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.ServingSize).IsRequired();

        
    }
}