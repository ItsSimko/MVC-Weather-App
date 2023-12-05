using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Database;

namespace SQ.TermProject.myWeather.Services
{
    public class BaseService
    {
        public AppDbContext DbContext { get; set; }

        public BaseService() 
        { 
            DbContext = new AppDbContext();
            DbContext.Database.EnsureCreated();
        }
    }
}
