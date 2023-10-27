using QuickOrderDomain.Entities;

namespace QuickOrderApplication.DTOs;

public record OrderResponseDto(Guid Id, DateTime OrderedAt, List<OrderItem> Items, decimal Total, string Status);