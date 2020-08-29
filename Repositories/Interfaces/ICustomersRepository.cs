using System.Collections.Generic;
using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}