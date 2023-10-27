namespace QuickOrderDomain.Entities;

public class OrderItem
{
    public OrderItem(MenuItem item, int quantity)
    {
        Id = Guid.NewGuid();
        Item = item;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public MenuItem Item { get; private set; }
    public int Quantity { get; private set; }
    
    public decimal Price => Item.Price * Quantity;
}