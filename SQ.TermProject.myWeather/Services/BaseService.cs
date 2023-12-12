using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Database;

namespace SQ.TermProject.myWeather.Services
{
    /// <summary>
    /// Base service providing access to the application's database context.
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Gets or sets the application's database context.
        /// </summary>
        public AppDbContext DbContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the BaseService class. And sets up DbContext
        /// </summary>
        public BaseService() 
        { 
            DbContext = new AppDbContext();
            DbContext.Database.EnsureCreated();
        }
    }
}
