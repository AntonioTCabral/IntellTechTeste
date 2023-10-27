using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderDomain.Entities;
using QuickOrderInfrastructure.DataBase;

namespace QuickOrderInfrastructure.Repositories;

public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(QuickOrderContext context) : base(context)
    {
    }
}