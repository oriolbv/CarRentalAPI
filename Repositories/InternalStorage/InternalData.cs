using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories.InternalStorage
{
    class InternalData
    {
        private static readonly InternalData _internalDataInstance = new InternalData();

        public Customer[] customers = {
            new Customer {
                Id = "1",
                Name = "Oriol",
                Surname = "Burgaya",
                BonusPoints = 0
            },
            new Customer {
                Id = "2",
                Name = "Queralt",
                Surname = "Sobira",
                BonusPoints = 0
            }
        };

        public Car[] cars = {
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

        private InternalData() {}

        public static InternalData GetInstance() => _internalDataInstance;

    }
}