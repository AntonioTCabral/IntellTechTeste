using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderApplication.Interfaces.Services;
using QuickOrderDomain.Entities;

namespace QuickOrderApplication.Services;

public class DisheItemService : IDisheItemService
{
    private readonly IDisheItemRepository _disheRepository;

    public DisheItemService(IDisheItemRepository disheRepository)
    {
        _disheRepository = disheRepository;
    }

    public async Task<List<DisheItem>> GetAllAsync() => await _disheRepository.GetAll();

    public async Task<DisheItem?> GetByIdAsync(Guid id) => await _disheRepository.GetById(id);

    public async Task AddAsync(DisheItem entity) => await _disheRepository.Add(entity);

    public async Task UpdateAsync(DisheItem entity) => await _disheRepository.Update(entity);

    public async Task DeleteAsync(DisheItem entity) => await _disheRepository.Delete(entity);
}