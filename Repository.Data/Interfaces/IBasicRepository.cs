using Repository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Interfaces
{
    public interface IBasicRepository<T> where T: IId
    {
        /// <summary>
        /// Returns an IQueryable object to be queried by.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();

        /// <summary>
        /// Based on a where/filter string, queries the entity in the database and orders it.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        IEnumerable<T> Get(string filter, string order);

        /// <summary>
        /// Returns an <typeparamref name="T"/> given an id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T? Get(Guid id);

        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(T entity);

        /// <summary>
        /// Deletes an entity given its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);
    }
}
