using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;

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

        public IActionResult Index(Guid personId)
        {
            var cars = this._carRepository
                .Query()
                .Where(x => x.PersonId == personId)
                .ToList();

            return View(cars);
        }
    }
}
