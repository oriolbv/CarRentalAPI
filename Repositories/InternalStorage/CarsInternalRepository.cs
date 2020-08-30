using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories.InternalStorage
{
    public class CarsInternalRepository : ICarsRepository
    {
        private Car[] cars = {
            new Car {
                Id = "1",
                Type = "SUV",
                Price = 100,
                Discount = 30,
                DiscountDays = 3,
                BonusPoints = 1,
                IsAvailable = true
            },
            new Car {
                Id = "2",
                Type = "Convertible",
                Price = 150,
                Discount = 0,
                DiscountDays = 0,
                BonusPoints = 2,
                IsAvailable = true
            },
            new Car {
                Id = "3",
                Type = "Mini Van",
                Price = 100,
                Discount = 20,
                DiscountDays = 5,
                BonusPoints = 1,
                IsAvailable = true
            }
        };

        public IEnumerable<Car> GetCars()
        {
            return cars;
        }

        public Car GetCarById(string id)
        {
            foreach (Car car in cars) 
            {
                if (car.Id.Equals(id)) return car;
            }
            return null;  
        }

        public int UpdateCarAvailability(string id, bool isAvailable) 
        {
            foreach (Car car in cars) 
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