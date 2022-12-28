using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Interfaces
{
    public interface IId
    {
        /// <summary>
        /// Key/Id.
        /// </summary>
        Guid Id { get; }
    }
}
