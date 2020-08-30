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
        public double GetRentalPrice(string customer_id, [FromBody]Rental[] rentals)
        {
            var customer = _customersService.GetCustomerById(customer_id);
            double totalPrice = 0;
            foreach(Rental rental in rentals) {
                var car = _carsService.GetCarById(rental.CarId);
                double price = 0;
                int _days = Convert.ToInt32(rental.Days);
                // Calculate the price of the car rental
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
                totalPrice += price;

                // Update customer bonus points
                _customersService.UpdateCustomerBonusPoints(customer_id, car.BonusPoints);
            }
            
            return totalPrice;
        }

        [Route("surcharges")]
        [HttpGet()]
        public double GetSurcharges([FromBody]Rental[] rentals)
        {
            double totalSurcharge = 0;
            foreach(Rental rental in rentals) {
                var car = _carsService.GetCarById(rental.CarId);
                // Multiply by the days of use and calculate price
                double surcharge = car.Price * Convert.ToInt32(rental.Days);
                totalSurcharge += surcharge;
            }
            return totalSurcharge;
        }
    }
}