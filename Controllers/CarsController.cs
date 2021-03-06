using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarRentalAPI.Models;
using CarRentalAPI.Services;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var cars = _carsService.GetCars();
            return cars.ToList();
        }

        [Route("detail")]
        [HttpGet()]
        public ActionResult<Car> GetCarById(string car_id)
        {
            var car = _carsService.GetCarById(car_id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
    }
}