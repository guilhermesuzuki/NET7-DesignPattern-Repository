using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Interfaces
{
    public interface IName
    {
        /// <summary>
        /// Person's First Name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Person's Last Name.
        /// </summary>
        string LastName { get; }
    }
}
