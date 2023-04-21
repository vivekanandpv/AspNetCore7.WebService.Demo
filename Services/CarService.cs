using AspNetCore7.WebService.Demo.Context;
using AspNetCore7.WebService.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore7.WebService.Demo.Services;

public class CarService : ICarService
{
    private readonly CarContext _context;

    public CarService(CarContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<Car> CreateAsync(Car car)
    {
        await _context.AddAsync(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task<Car> UpdateAsync(int id, Car car)
    {
        var carDb = await GetByIdAsync(id);

        carDb.Make = car.Make;
        carDb.Model = car.Model;
        carDb.Color = car.Color;
        carDb.Year = car.Year;
        carDb.FuelType = car.FuelType;
        
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task DeleteAsync(int id)
    {
        var carDb = await GetByIdAsync(id);

        _context.Cars.Remove(carDb);
        
        await _context.SaveChangesAsync();
    }
}