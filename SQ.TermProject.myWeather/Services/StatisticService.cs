using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;

namespace SQ.TermProject.myWeather.Services
{
    public class StatisticService : BaseService
    {
        public void UpdateSiteHeader(string city)
        {
            // Retrieve the entity from the database
            var entity = DbContext.SearchStat.FirstOrDefault(e => e.Location == city);

            if (entity != null)
            {
                entity.SearchCount++;
                DbContext.SaveChanges();
            }
            //else
            {
                var newSearchStat = new SearchStat
                {
                    Location = city,
                    SearchCount = 1
                };

                // Add the new instance to the DbContext
                DbContext.SearchStat.Add(newSearchStat);
            }
        }
    }
}
