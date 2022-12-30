using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;
using Repository.Site.ViewModels;
using System.Transactions;

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
            var people = this._personRepository.Query().OrderBy(x => x.LastName).ToList();

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

        /// <summary>
        /// Saves the new person
        /// </summary>
        /// <param name="pvm"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult New(PersonViewModel pvm)
        {
            if (pvm != null)
            {
                using (var ts = new TransactionScope())
                {
                    this._personRepository.Add(pvm.Person);
                    foreach (var car in pvm.Cars) this._carRepository.Add(car);
                    ts.Complete();
                }

                return Ok(true);
            }

            return BadRequest();
        }

        /// <summary>
        /// Edits the existing person, modifying cars/adding new cars.
        /// </summary>
        /// <param name="pvm"></param>
        /// <returns></returns>
        public IActionResult Edit(PersonViewModel pvm)
        {
            if (pvm != null)
            {
                using (var ts = new TransactionScope())
                {
                    this._personRepository.Update(pvm.Person);
                    foreach (var car in pvm.Cars)
                    {
                        //deletes a car
                        if (car.Id != Guid.Empty && car.Deleted)
                        {
                            this._carRepository.Delete(car.Id);
                            continue;
                        }

                        //updates the info from an existing car
                        if (car.Id != Guid.Empty)
                        {
                            this._carRepository.Update(car);
                            continue;
                        }

                        //adds a new car
                        if (car.Id == Guid.Empty)
                        {
                            this._carRepository.Add(car);
                            continue;
                        }
                    }

                    ts.Complete();
                }

                return Ok(true);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deletes a person and their cars.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid personId)
        {
            if (personId != Guid.Empty)
            {
                using (var ts = new TransactionScope())
                {
                    var cars = this._carRepository
                        .Query()
                        .Where(x => x.PersonId == personId)
                        .ToList();

                    foreach (var car in cars) this._carRepository.Delete(car.Id);
                    this._personRepository.Delete(personId);

                    ts.Complete();
                }

                return Ok(true);
            }

            return BadRequest();
        }
    }
}
