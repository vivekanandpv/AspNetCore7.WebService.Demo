using AspNetCore7.WebService.Demo.Models;

namespace AspNetCore7.WebService.Demo.Services;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car> GetByIdAsync(int id);
    Task<Car> CreateAsync(Car car);
    Task<Car> UpdateAsync(int id, Car car);
    Task DeleteAsync(int id);
}