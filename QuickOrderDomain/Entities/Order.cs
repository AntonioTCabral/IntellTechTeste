using QuickOrderDomain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickOrderDomain.Entities;

public class Order
{
    
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime OrderedAt { get; private set; } = DateTime.Now;
    public List<OrderItem> Items { get; private set; } = new();
    public decimal Total => Items.Sum(item => item.Price);
    public OrderStatus Status { get; private set; } = OrderStatus.Preparing;

    public void AddItem(DisheItem menuItem, int quantity)
    {
        Items.Add(new OrderItem(menuItem, quantity));
    }
    
    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
    }

}
