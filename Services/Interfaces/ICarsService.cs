using System.Collections.Generic;
using CarRentalAPI.Models;

namespace CarRentalAPI.Services
{
    public interface ICarsService
    {
        IEnumerable<Car> GetCars();
    }
}