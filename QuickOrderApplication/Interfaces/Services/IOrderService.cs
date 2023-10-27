using QuickOrderApplication.DTOs;
using QuickOrderDomain.Entities;
using QuickOrderDomain.Enums;

namespace QuickOrderApplication.Interfaces.Services;

public interface IOrderService
{
    Task<Order> PlaceOrderAsync(OrderDto order);
    Task<IEnumerable<OrderResponseDto>> GetAllAsync();
    Task<OrderResponseDto> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateStatusAsync(Guid id, OrderStatus status);
}