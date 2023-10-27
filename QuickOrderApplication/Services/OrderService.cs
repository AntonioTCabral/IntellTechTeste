using QuickOrderApplication.DTOs;
using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderApplication.Interfaces.Services;
using QuickOrderDomain.Entities;

namespace QuickOrderApplication.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDisheItemRepository _disheItemRepository;

    public OrderService(IOrderRepository orderRepository, IDisheItemRepository disheItemRepository)
    {
        _orderRepository = orderRepository;
        _disheItemRepository = disheItemRepository;
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
    
}