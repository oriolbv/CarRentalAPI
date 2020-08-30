using System.Collections.Generic;
using CarRentalAPI.Models;

namespace CarRentalAPI.Services
{
    public interface ICarsService
    {
        IEnumerable<Car> GetCars();
        Car GetCarById(string id);
        int UpdateCarAvailability(string id, bool isAvailable);
    }
}