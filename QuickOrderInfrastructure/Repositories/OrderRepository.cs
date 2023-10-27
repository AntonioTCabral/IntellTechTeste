using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderDomain.Entities;
using QuickOrderInfrastructure.DataBase;

namespace QuickOrderInfrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(QuickOrderContext context) : base(context)
    {
    }
}
