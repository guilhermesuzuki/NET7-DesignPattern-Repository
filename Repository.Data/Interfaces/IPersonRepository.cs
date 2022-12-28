using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Interfaces
{
    public interface IPersonRepository: IBasicRepository<Person>
    {
    }
}
