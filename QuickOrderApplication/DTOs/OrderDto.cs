using QuickOrderDomain.Enums;

namespace QuickOrderApplication.DTOs;

public class OrderDto
{
    public List<DishSelectionDto> DishSelections { get; set; }
}