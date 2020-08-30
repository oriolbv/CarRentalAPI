using System;
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

        [Route("price")]
        [HttpGet()]
        public double GetRentalPrice(string customer_id, string car_id, string days)
        {
            var customer = _customersService.GetCustomerById(customer_id);
            var car = _carsService.GetCarById(car_id);
            // Multiply by the days of use and calculate price
            double price = 0;
            int _days = Convert.ToInt32(days);
            // Calculate the bonus points of the customer
            if (_days > 0) 
            {
                // Check available discounts for the car rented
                if (car.DiscountDays > 0 && _days > car.DiscountDays) 
                {
                    // Calculate first price without discount days applied
                    price = car.Price * car.DiscountDays;
                    
                    _days -= car.DiscountDays;

                    // Add discounted price days into final rental price
                    double discountedPrice = car.Price - (car.Price * (car.Discount/100));
                    price += discountedPrice * _days;
                }
                else
                {
                    price = car.Price * _days;
                }
            }
            return price;
        }

        [Route("surcharges")]
        [HttpGet()]
        public double GetSurcharges(string car_id, string extra_days)
        {
            var car = _carsService.GetCarById(car_id);
            // Multiply by the days of use and calculate price
            double price = 0;

            
            return price;
        }
    }
}