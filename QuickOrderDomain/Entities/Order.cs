using QuickOrderDomain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickOrderDomain.Entities;

public class Order
{
    public Order()
    {
        Id = Guid.NewGuid();
        OrderedAt = DateTime.Now;
        Status = OrderStatus.Preparing;
    }
    
    
    public Guid Id { get; private set; }
    public DateTime OrderedAt { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();
    public decimal Total => Items.Sum(item => item.Price);
    public OrderStatus Status { get; private set; }

    public void AddItem(DisheItem menuItem, int quantity)
    {
        Items.Add(new OrderItem(menuItem, quantity));
    }
    
    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
    }

}
