using QuickOrderDomain.Enums;

namespace QuickOrderDomain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime OrderedAt { get; private set; } = DateTime.Now;
    public List<OrderItem> Items { get; private set; } = new();
    public decimal Total => Items.Sum(item => item.Price);
    public OrderStatus Status { get; set; }
    
    public void AddItem(DisheItem disheItem, int quantity)
    {
        Items.Add(new OrderItem(disheItem, quantity));
    }
}