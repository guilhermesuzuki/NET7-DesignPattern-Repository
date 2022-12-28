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
    /// Person Repository Class.
    /// </summary>
    public class PersonRepository: _BasicRepository<Person>,
        Interfaces.IPersonRepository
    {
        /// <summary>
        /// Constructor with DI.
        /// </summary>
        /// <param name="configuration"></param>
        public PersonRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
