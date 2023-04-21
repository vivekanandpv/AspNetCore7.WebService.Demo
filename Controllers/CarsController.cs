using AspNetCore7.WebService.Demo.Models;
using AspNetCore7.WebService.Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7.WebService.Demo.Controllers;

[Route("api/v1/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _service;

    public CarsController(ICarService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetAllAsync()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Car>> GetByIdAsync(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Car>> CreateAsync(Car car)
    {
        return Ok(await _service.CreateAsync(car));
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Car>> UpdateAsync(int id, Car car)
    {
        return Ok(await _service.UpdateAsync(id, car));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}