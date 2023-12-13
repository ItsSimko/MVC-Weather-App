﻿using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;

namespace SQ.TermProject.myWeather.Services
{
    public class StatisticService : BaseService
    {
        public void UpdateStat(string city)
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
                DbContext.SaveChanges();
            }
        }


        public int GetStat(string city)
        {
            var result = DbContext.SearchStat.FirstOrDefault(e => e.Location == city);
            return result.SearchCount;
        }

        public List<SearchStat> GetTop10SearchStats()
        {
            try
            {
                var top10SearchStats = DbContext.SearchStat
                    .OrderByDescending(s => s.SearchCount)
                    .Take(10)
                    .ToList();

                return top10SearchStats;

            }
            catch (Exception ex)
            {
                LoggerService.Log($"Exception Thrown: {ex.Message}");
                return null;
            }
        }
    }
}
