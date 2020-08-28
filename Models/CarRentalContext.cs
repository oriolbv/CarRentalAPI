using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Models
{
    public class CarRentalContext : DbContext
    {
        public TodoContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
    }
}