using QuickOrderApplication.DTOs;
using QuickOrderDomain.Entities;
using QuickOrderDomain.Enums;

namespace QuickOrderApplication.Interfaces.Services;

public interface IOrderService
{
    Task PlaceOrderAsync(OrderDto order);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateStatusAsync(Guid id, OrderStatus status);
}