namespace QuickOrderDomain.Entities;

public class DisheItem
{
    public DisheItem(string name, decimal price, string description, string photoUrl, int servingSize)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        PhotoUrl = photoUrl;
        ServingSize = servingSize;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public string PhotoUrl { get; private set; }
    public int ServingSize { get; private set; }
}