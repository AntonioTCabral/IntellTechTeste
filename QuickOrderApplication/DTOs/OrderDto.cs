namespace QuickOrderApplication.DTOs;

public record OrderDto(List<DishSelectionDto> DishSelections, string Status);