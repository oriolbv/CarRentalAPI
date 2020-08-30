using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories.InternalStorage
{
    public class CustomersInternalRepository : ICustomersRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {           
            return InternalData.GetInstance().customers;
        }

        public Customer GetCustomerById(string id) 
        {
            foreach (Customer customer in InternalData.GetInstance().customers) 
            {
                if (customer.Id.Equals(id)) return customer;
            }
            return null;    
        }

        public int UpdateCustomerBonusPoints(string id, int bonusPoints) {
            for (int i = 0; i < InternalData.GetInstance().customers.Length; ++i) 
            {
                if (InternalData.GetInstance().customers[i].Id.Equals(id)) 
                {
                    InternalData.GetInstance().customers[i].BonusPoints += bonusPoints;
                    return 0;
                }
            }
            return -1; 
        }
    }
}