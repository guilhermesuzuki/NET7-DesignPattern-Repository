using Microsoft.Extensions.Configuration;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Implementations
{
    /// <summary>
    /// Car Repository Class.
    /// </summary>
    public class CarRepository: _BasicRepository<Car>,
        Interfaces.ICarRepository
    {
        /// <summary>
        /// Constructor with DI.
        /// </summary>
        /// <param name="configuration"></param>
        public CarRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
