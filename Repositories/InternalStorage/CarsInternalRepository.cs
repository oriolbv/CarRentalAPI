using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories.InternalStorage
{
    public class CarsInternalRepository : ICarsRepository
    {
        

        public IEnumerable<Car> GetCars()
        {
            return InternalData.GetInstance().cars;
        }

        public Car GetCarById(string id)
        {
            foreach (Car car in InternalData.GetInstance().cars) 
            {
                if (car.Id.Equals(id)) return car;
            }
            return null;  
        }

        public int UpdateCarAvailability(string id, bool isAvailable) 
        {
            foreach (Car car in InternalData.GetInstance().cars) 
            {
                if (car.Id.Equals(id)) 
                {
                    car.IsAvailable = isAvailable;
                    return 0;
                }
            }
            return -1; 
        }
    }
}