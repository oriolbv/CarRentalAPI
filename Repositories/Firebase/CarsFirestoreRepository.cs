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
            string filepath = Path.Combine(AppContext.BaseDirectory + "/carrentalapi-c005eefa1574.json");  
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);  
            fireStoreDb = FirestoreDb.Create(PROJECT_ID);
            
        }

        public IEnumerable<Car> GetCars()
        {           
            Query carsRef = fireStoreDb.Collection("cars");
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
                        DiscountDays = Convert.ToDouble(dictionary["discount_days"])
                    };
                })
                .ToList();
        }
    }
}