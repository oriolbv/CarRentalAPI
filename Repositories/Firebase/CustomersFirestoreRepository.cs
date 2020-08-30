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

namespace CarRentalAPI.Repositories.Firestore
{
    public class CustomersFirestoreRepository : ICustomersRepository
    {
        private const string PROJECT_ID = "carrentalapi";
        private FirestoreDb fireStoreDb;

        public CustomersFirestoreRepository()
        {
            string filepath = Path.Combine(AppContext.BaseDirectory + "/carrentalapi-c005eefa1574.json");  
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);  
            fireStoreDb = FirestoreDb.Create(PROJECT_ID);
        }

        public IEnumerable<Customer> GetCustomers()
        {           
            Query customersRef = fireStoreDb.Collection("customers");
            var snapshot = customersRef.GetSnapshotAsync().Result;

            return snapshot.Documents
                .Select(document =>
                {
                    ;
                    var dictionary = document.ToDictionary();
                    return new Customer
                    {
                        Id = document.Id,
                        Name = dictionary["name"].ToString(),
                        Surname = dictionary["surname"].ToString(),
                        BonusPoints = Convert.ToInt32(dictionary["bonus_points"])
                    };
                })
                .ToList();
        }

        public Customer GetCustomerById(string id) 
        {
            var customerRef = fireStoreDb.Collection("customers").Document(id);
            var snapshot = customerRef.GetSnapshotAsync().Result;
            if (snapshot.Exists) 
            {
                var dictionary = snapshot.ToDictionary();
                return new Customer
                    {
                        Id = customerRef.Id,
                        Name = dictionary["name"].ToString(),
                        Surname = dictionary["surname"].ToString(),
                        BonusPoints = Convert.ToInt32(dictionary["bonus_points"])
                    };
            }

            return null;    
        }
    }
}