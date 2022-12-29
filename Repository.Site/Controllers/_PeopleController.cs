using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;
using Repository.Models;
using System.Transactions;

namespace Repository.Site.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class _PeopleController : ControllerBase
    {
        protected readonly IPersonRepository _personRepository;

        /// <summary>
        /// Constructor with DI.
        /// </summary>
        /// <param name="personRepository"></param>
        public _PeopleController(IPersonRepository personRepository)
            : base()
        {
            this._personRepository = personRepository;
        }

        /// <summary>
        /// Adds the person in the database.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Person person)
        {
            if (ModelState.IsValid == false) return UnprocessableEntity(this.ModelState);
            using (var ts = new TransactionScope())
            {
                var result = this._personRepository.Add(person);
                ts.Complete();
                return Ok(result);
            }
        }

        /// <summary>
        /// Deletes the person in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            using (var ts = new TransactionScope())
            {
                var result = this._personRepository.Delete(id);
                ts.Complete();
                return Ok(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Person> Get(string where, string order)
        {
            return this._personRepository.Get(where, order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public Person? Get(Guid id)
        {
            return this._personRepository.Get(id);
        }

        /// <summary>
        /// Updates a person in the database.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Person person)
        {
            if (ModelState.IsValid == false) return UnprocessableEntity(this.ModelState);
            using (var ts = new TransactionScope())
            {
                var result = this._personRepository.Update(person);
                ts.Complete();
                return Ok(result);
            }
        }
    }
}
