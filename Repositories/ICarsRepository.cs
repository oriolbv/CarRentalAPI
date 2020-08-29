using System.Collections.Generic;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories
{
    public interface ICarsRepository
    {
        IEnumerable<Car> GetCars();
    }
}