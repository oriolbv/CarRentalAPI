using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarRentalAPI.Models;
using CarRentalAPI.Services;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private ICarsService _carsService;
        private ICustomersService _customersService;

        public RentalController(ICarsService carsService, ICustomersService customersService)
        {
            _carsService = carsService;
            _customersService = customersService;
        }

        [HttpGet("{customer_id}/{car_id}/{days}")]
        public double GetRentalPrice(string customerId, string carId, string days)  // customer_id, car_id, days
        {
            var customerId = _customersService.GetCustomerById(customerId);
            var car = _carsService.GetCarById(carId);
            // Multiply by the days of use and calculate price
            double price = 0;

            // Calculate the bonus points of the customer

            
            return price;
        }
    }
}