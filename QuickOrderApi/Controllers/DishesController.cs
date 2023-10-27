using Microsoft.AspNetCore.Mvc;
using QuickOrderApplication.Interfaces.Services;
using QuickOrderDomain.Entities;

namespace QuickOrderApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DishesController : ControllerBase
{
    private readonly IDisheItemService _disheItemService;

    public DishesController(IDisheItemService disheItemService)
    {
        _disheItemService = disheItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _disheItemService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _disheItemService.GetByIdAsync(id);

        if (result is null)
            return NotFound("Dish not found!");

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] DisheItem disheItem)
    {
        await _disheItemService.AddAsync(disheItem);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DisheItem disheItem)
    {
        await _disheItemService.UpdateAsync(disheItem);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _disheItemService.DeleteAsync(id);
        return Ok();
    }
}