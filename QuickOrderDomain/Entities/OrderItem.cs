namespace QuickOrderDomain.Entities;

public class OrderItem
{
    public OrderItem(DisheItem dishes, int quantity)
    {
        Id = Guid.NewGuid();
        Dishes = dishes;
        Quantity = quantity;
    }

    public OrderItem()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
    public DisheItem Dishes { get; private set; }
    public int Quantity { get; private set; }
    
    public decimal Price => Dishes.Price * Quantity;
}