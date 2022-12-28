using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;

namespace Repository.Site.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IPersonRepository _personRepository;
        protected readonly ICarRepository _carRepository;

        /// <summary>
        /// Constructor with DI.
        /// </summary>
        /// <param name="personRepository"></param>
        /// <param name="carRepository"></param>
        public HomeController(
            IPersonRepository personRepository, 
            ICarRepository carRepository)
            : base()
        {
            this._personRepository = personRepository;
            this._carRepository = carRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
