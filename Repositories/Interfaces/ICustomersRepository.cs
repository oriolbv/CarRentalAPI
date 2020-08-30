using System.Collections.Generic;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(string id);
        int UpdateCustomerBonusPoints(string id, int bonusPoints);
    }
}