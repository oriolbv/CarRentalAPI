using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using CarRentalAPI.Models;
using Serilog;

namespace CarRentalAPI.Repositories.Firestore
{
    public class CarsFirestoreRepository : ICarsRepository
    {
        private const string PROJECT_ID = "carrentalapi";
        private FirestoreDb fireStoreDb;

        public CarsFirestoreRepository()
        {
            string filepath = Path.Combine(AppContext.BaseDirectory + "/carrentalapi.json");  
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);  
            fireStoreDb = FirestoreDb.Create(PROJECT_ID);
            
        }

        public IEnumerable<Car> GetCars()
        {           
            var carsRef = fireStoreDb.Collection("cars");
            var snapshot = carsRef.GetSnapshotAsync().Result;

            return snapshot.Documents
                .Select(document =>
                {
                    ;
                    var dictionary = document.ToDictionary();
                    return new Car
                    {
                        Id = document.Id,
                        Type = dictionary["type"].ToString(),
                        Price = Convert.ToDouble(dictionary["price"]),
                        Discount = Convert.ToDouble(dictionary["discount"]),
                        DiscountDays = Convert.ToInt32(dictionary["discount_days"]),
                        IsAvailable = Convert.ToBoolean(dictionary["is_available"])
                    };
                })
                .ToList();
        }

        public Car GetCarById(string id) 
        {
            var carRef = fireStoreDb.Collection("cars").Document(id);
            var snapshot = carRef.GetSnapshotAsync().Result;
            if (snapshot.Exists) 
            {
                var dictionary = snapshot.ToDictionary();
                return new Car
                    {
                        Id = carRef.Id,
                        Type = dictionary["type"].ToString(),
                        Price = Convert.ToDouble(dictionary["price"]),
                        Discount = Convert.ToDouble(dictionary["discount"]),
                        DiscountDays = Convert.ToInt32(dictionary["discount_days"]),
                        BonusPoints = Convert.ToInt32(dictionary["bonus_points"]),
                        IsAvailable = Convert.ToBoolean(dictionary["is_available"])
                    };
            }

            return null;
        }

        public int UpdateCarAvailability(string id, bool isAvailable) 
        {
            var carRef = fireStoreDb.Collection("cars").Document(id);
            var snapshot = carRef.GetSnapshotAsync().Result;
            if (!snapshot.Exists) 
            {
                return -1;
            } 
            else 
            {
                var dictionary = snapshot.ToDictionary();
                dictionary["is_available"] = isAvailable;
                carRef.UpdateAsync(dictionary);
            }
            return 0;
        }

    }
}