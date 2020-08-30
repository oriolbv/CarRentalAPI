using System.Collections.Generic;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customersRepository.GetCustomers();
        }

        public Customer GetCustomerById(string id) 
        {
            return _customersRepository.GetCustomerById(id);
        }

        public int UpdateCustomerBonusPoints(string id, int bonusPoints) 
        {
            return _customersRepository.UpdateCustomerBonusPoints(id, bonusPoints);
        }
    }
}