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
        modelBuilder.Entity<Order>().HasMany(x => x.Items).WithOne().HasForeignKey(o => o.Id).OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId);
        
        
        modelBuilder.Entity<DisheItem>().HasKey(x => x.Id);
        modelBuilder.Entity<DisheItem>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.Price).HasColumnType("decimal(18, 2)").IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.Description).IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.ImageUrl).IsRequired();
        modelBuilder.Entity<DisheItem>().Property(x => x.ServingSize).IsRequired();

        
    }
}