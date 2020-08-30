using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarRentalAPI.Models;
using CarRentalAPI.Services;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            var customers = _customersService.GetCustomers();
            return customers.ToList();
        }

        [Route("detail")]
        [HttpGet()]
        public ActionResult<Customer> GetCustomerById(string customer_id)
        {
            var customer = _customersService.GetCustomerById(customer_id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
    }
}