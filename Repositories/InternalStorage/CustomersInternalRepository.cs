using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories.InternalStorage
{
    public class CustomersInternalRepository : ICustomersRepository
    {

        private Customer[] customers = {
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
        public IEnumerable<Customer> GetCustomers()
        {           
            return customers;
        }

        public Customer GetCustomerById(string id) 
        {
            foreach (Customer customer in customers) 
            {
                if (customer.Id.Equals(id)) return customer;
            }
            return null;    
        }

        public int UpdateCustomerBonusPoints(string id, int bonusPoints) {
            
            foreach (Customer customer in customers) 
            {
                if (customer.Id.Equals(id)) 
                {
                    customer.BonusPoints += bonusPoints;
                    return 0;
                }
            }
            return -1; 
        }
    }
}