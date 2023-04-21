using AspNetCore7.WebService.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore7.WebService.Demo.Context;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
        
    }

    public DbSet<Car> Cars { get; set; }
}