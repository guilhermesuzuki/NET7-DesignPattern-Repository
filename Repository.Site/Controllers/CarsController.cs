using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;
using Repository.Models;

namespace Repository.Site.Controllers
{
    public class CarsController : Controller
    {
        protected readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
            : base()
        {
            this._carRepository = carRepository;
        }

        [HttpPost]
        public IActionResult Car(Car car)
        {
            return View(car);
        }

        [HttpGet]
        public IActionResult Cars(Guid personId)
        {
            var cars = this._carRepository
                .Query()
                .Where(x => x.PersonId == personId)
                .ToList();

            return View(cars);
        }
    }
}
