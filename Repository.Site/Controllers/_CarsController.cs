using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Interfaces;
using Repository.Models;
using System.Transactions;

namespace Repository.Site.Controllers
{
    /// <summary>
    /// Cars API Controller
    /// </summary>
    [ApiController]
    [Route("api/cars")]
    public class _CarsController : ControllerBase
    {
        protected readonly ICarRepository _carRepository;

        public _CarsController(ICarRepository carRepository)
            : base()
        {
            this._carRepository = carRepository;
        }

        /// <summary>
        /// Adds the person in the database.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid == false) return UnprocessableEntity(this.ModelState);
            using (var ts = new TransactionScope())
            {
                var result = this._carRepository.Add(car);
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
                var result = this._carRepository.Delete(id);
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
        public IEnumerable<Car> Get(string where, string order)
        {
            return this._carRepository.Get(where, order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public Car? Get(Guid id)
        {
            return this._carRepository.Get(id);
        }

        /// <summary>
        /// Updates a person in the database.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Car car)
        {
            if (ModelState.IsValid == false) return UnprocessableEntity(this.ModelState);
            using (var ts = new TransactionScope())
            {
                var result = this._carRepository.Update(car);
                ts.Complete();
                return Ok(result);
            }
        }
    }
}
