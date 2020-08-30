using System.Collections.Generic;
using CarRentalAPI.Models;

namespace CarRentalAPI.Services
{
    public interface ICustomersService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(string id);
        int UpdateCustomerBonusPoints(string id, int bonusPoints);
    }
}