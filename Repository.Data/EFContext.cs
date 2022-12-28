using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Models;

namespace Repository.Data
{
    /// <summary>
    /// EntityFramework Database Context for the Solution.
    /// It's internal, because the solution implements the Repository pattern.
    /// </summary>
    internal class EFContext: DbContext
    {
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor with DI.
        /// </summary>
        /// <param name="configuration"></param>
        public EFContext(IConfiguration configuration)
            : base()
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Repository")).EnableDetailedErrors();
        }

        /// <summary>
        /// People
        /// </summary>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// Cars
        /// </summary>
        public DbSet<Car> Cars { get; set; }
    }
}