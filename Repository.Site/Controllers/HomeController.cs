using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;
using Repository.Site.ViewModels;

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
            var pvm = new PeopleViewModel();
            var people = this._personRepository.Query().ToList();

            //obtains all the cars from each person
            foreach (var person in people)
            {
                var cars = this._carRepository
                    .Query()
                    .Where(x => x.PersonId == person.Id)
                    .ToList();

                pvm.People.Add(new PersonViewModel { Person = person, Cars = cars });
            }

            return View(pvm);
        }
    }
}
