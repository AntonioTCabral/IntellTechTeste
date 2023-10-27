using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderDomain.Entities;
using QuickOrderInfrastructure.DataBase;

namespace QuickOrderInfrastructure.Repositories;

public class DisheItemRepository : RepositoryBase<DisheItem>, IDisheItemRepository
{
    public DisheItemRepository(QuickOrderContext context) : base(context)
    {
    }
}