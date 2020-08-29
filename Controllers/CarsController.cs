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

        // [HttpGet]
        // // [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        // // [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        // // [ProducesResponseType(500)]
        // // public ActionResult<List<Car>> Get()
        // public string Get()
        // {
        //     return "holi";
        //     // var cars = _carsService.GetCars();
        //     // return cars.ToList();
        // }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var cars = _carsService.GetCars();
            return cars.ToList();
        }
    }
}