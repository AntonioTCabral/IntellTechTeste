using QuickOrderDomain.Entities;

namespace QuickOrderApplication.Interfaces.Services;

public interface IDisheItemService
{
    Task<List<DisheItem>> GetAllAsync();
    Task<DisheItem?> GetByIdAsync(Guid id);
    Task AddAsync(DisheItem entity);
    Task UpdateAsync(DisheItem entity);
    Task DeleteAsync(Guid id);
}