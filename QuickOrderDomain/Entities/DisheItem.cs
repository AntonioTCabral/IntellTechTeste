namespace QuickOrderDomain.Entities;

public class DisheItem
{
    public DisheItem(string name, decimal price, string description, string imageUrl, string servingSize)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        ImageUrl = imageUrl;
        ServingSize = servingSize;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public string ServingSize { get; private set; }
}