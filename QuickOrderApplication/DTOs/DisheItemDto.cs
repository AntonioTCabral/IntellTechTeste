namespace QuickOrderApplication.DTOs;

public class DisheItemDto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public string ServingSize { get; private set; }
}