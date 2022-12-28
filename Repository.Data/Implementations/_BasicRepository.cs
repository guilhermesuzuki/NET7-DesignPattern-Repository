using Microsoft.Extensions.Configuration;
using Repository.Data.Interfaces;
using Repository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repository.Data.Implementations
{
    /// <summary>
    /// Basic Repository abstract class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class _BasicRepository<T> : IBasicRepository<T> where T : class, IId
    {
        /// <summary>
        /// Configuration for the EF database context.
        /// </summary>
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor with DI.
        /// </summary>
        /// <param name="configuration"></param>
        public _BasicRepository(IConfiguration configuration)
            : base()
        {
            this._configuration = configuration;
        }

        public bool Add(T entity)
        {
            try
            {
                using (var ef = new EFContext(this._configuration))
                {
                    ef.Add(entity);
                    ef.SaveChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var entity = this.Get(id);
                if (entity != null)
                {
                    using (var ef = new EFContext(this._configuration))
                    {
                        ef.Remove(entity);
                        ef.SaveChanges();

                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> Get(string where, string order)
        {
            using (var ef = new EFContext(this._configuration))
            {
                var query = this.Query();

                if (string.IsNullOrWhiteSpace(where) == false) query = query.Where(where);
                if (string.IsNullOrWhiteSpace(order) == false) query = query.OrderBy(order);

                return query.ToList();
            }
        }

        public T? Get(Guid id)
        {
            return this.Query().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> Query()
        {
            var ef = new EFContext(this._configuration);
            return ef.Set<T>().AsQueryable();
        }

        public bool Update(T entity)
        {
            try
            {
                using (var ef = new EFContext(this._configuration))
                {
                    ef.Update(entity);
                    ef.SaveChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
