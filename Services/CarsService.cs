using System.Collections.Generic;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;

        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public IEnumerable<Car> GetCars()
        {
            return _carsRepository.GetCars();
        }

        public Car GetCarById(string id) 
        {
            return _carsRepository.GetCarById(id);
        }
        
        public int UpdateCarAvailability(string id, bool isAvailable) 
        {
            return _carsRepository.UpdateCarAvailability(id, isAvailable);
        }
    }
}