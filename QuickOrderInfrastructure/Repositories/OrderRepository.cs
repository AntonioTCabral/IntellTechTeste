using Microsoft.EntityFrameworkCore;
using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderDomain.Entities;
using QuickOrderInfrastructure.DataBase;

namespace QuickOrderInfrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    private readonly QuickOrderContext _context;
    public OrderRepository(QuickOrderContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<List<Order>> GetAll()
    {
        var result = await _context.Orders.AsNoTracking().Include(x => x.Items).ThenInclude(o => o.Dishes).ToListAsync();

        return result;
    }

    public override Task<Order?> GetById(Guid id)
    {
        return _context.Orders.AsNoTracking().Include(x => x.Items).ThenInclude(o => o.Dishes).FirstOrDefaultAsync(x => x.Id == id);
    }
}
