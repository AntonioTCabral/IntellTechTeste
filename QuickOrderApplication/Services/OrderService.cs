using Microsoft.AspNetCore.SignalR;
using QuickOrderApplication.DTOs;
using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderApplication.Interfaces.Services;
using QuickOrderApplication.Services.SignalIR;
using QuickOrderDomain.Entities;
using QuickOrderDomain.Enums;

namespace QuickOrderApplication.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDisheItemRepository _disheItemRepository;
    private readonly IHubContext<OrderStatusHub> _hubContext;

    public OrderService(IOrderRepository orderRepository, IDisheItemRepository disheItemRepository, IHubContext<OrderStatusHub> hubContext)
    {
        _orderRepository = orderRepository;
        _disheItemRepository = disheItemRepository;
        _hubContext = hubContext;
    }

    public async Task PlaceOrderAsync(OrderDto order)
    {
        var orderEntity = new Order();
        
        foreach (var item in order.Items)
        {
            var dishe = await _disheItemRepository.GetById(item.DisheId);
            
            if (dishe == null) throw new Exception("Dishe not found.");
            
            orderEntity.AddItem(dishe, item.Quantity);
        }
        
        await _orderRepository.Add(orderEntity);
    }

    public async Task<IEnumerable<Order>> GetAllAsync() => await _orderRepository.GetAll();

    public async Task<Order> GetByIdAsync(Guid id) => await _orderRepository.GetById(id);

    public async Task DeleteAsync(Guid id)
    {
        var order = await _orderRepository.GetById(id);
        await _orderRepository.Delete(order);
    }

    public async Task UpdateStatusAsync(Guid id, OrderStatus status)
    {
        var orderEntity = await _orderRepository.GetById(id);
        
        if (orderEntity == null) throw new Exception("Order not found.");
        
        orderEntity.UpdateStatus(status);
        
        await _orderRepository.Update(orderEntity);
        
        await _hubContext.Clients.Group(id.ToString()).SendAsync("UpdateOrderStatus", orderEntity.Status.ToString());
    }
}