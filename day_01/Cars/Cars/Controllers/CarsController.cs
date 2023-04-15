using Cars.database;
using Cars.Filters;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Cars.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        public ILogger<CarsController> logger { get; set; }

        public CarsController(ILogger<CarsController> _logger) 
        {
            logger= _logger;
        }
        [HttpGet]
        public ActionResult<List<Car>> getAllCars()
        {
            logger.LogInformation("get all cars in database");
            return Ok(dbContext.cars);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult getCarById (int carId)
        {
            logger.LogInformation($"get car by id where id = {carId}");
            Car car = dbContext.cars.Where(car => car.id == carId).FirstOrDefault();
            if (car != null)
            {
                return Ok(car);
            }

            return NotFound();
        }
        [HttpPost]
        [Route("v1")]
        public ActionResult addCar(Car car)
        {
            car.id = dbContext.cars.Count + 1;
            car.type = "Gas";
            dbContext.cars.Add(car);
            return CreatedAtAction(actionName: nameof(getCarById),
            routeValues: new { id = car.id },
            new { Message = "car added Successfuly" });
        }
        [HttpPost]
        [Route("v2")]
        [ValidateCarType]
        public ActionResult addCar_v2(Car car)
        {
            car.id = dbContext.cars.Count + 1;
            car.type = car.type;
            dbContext.cars.Add(car);
            return CreatedAtAction(actionName: nameof(getCarById),
            routeValues: new { id = car.id },
            new { Message = "car added Successfuly" });
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult updateCar(Car car , int id)
        {
            if (car.id != id) {
                return BadRequest();
            }

            Car updatedCar = dbContext.cars.Where(car => car.id == id).FirstOrDefault();
            if (updatedCar == null)
            {
                return NotFound();
            }

            updatedCar.name = car.name;
            updatedCar.price = car.price;
            updatedCar.type = car.type;
            updatedCar.ProductionDate = car.ProductionDate;
        
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult deleteCar(int id)
        {
            logger.LogInformation($"delete car which id = {id}");
            Car car = dbContext.cars.FirstOrDefault(car => car.id == id);
            if (car == null) { 
            return NotFound();
            }
            dbContext.cars.Remove(car);
            return NoContent();
        }
    }
}
