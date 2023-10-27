﻿namespace QuickOrderApplication.DTOs;

public class DisheItemDto
{
    public Guid Id { get;  set; }
    public string Name { get;  set; }
    public decimal Price { get;  set; }
    public string Description { get;  set; }
    public string ImageUrl { get;  set; }
    public string ServingSize { get;  set; }
}