using SQ.TermProject.myWeather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class StatTest
    {
        private StatisticService statisticService;
        public StatTest() 
        {
            statisticService = new StatisticService();
        }

        [TestMethod]
        public void GetTestSearchCount_SampleSearch_KnowCount()
        {
            string cityInput = "testCity";

            int expected = -23;

            int act = statisticService.GetStat(cityInput);

            Assert.AreEqual(expected, act);

        }

        [TestMethod]
        public void GetWrongTestSearchCount_SampleSearch_IncorrectCount()
        {
            string cityInput = "testCity";

            int expected = 25;

            int act = statisticService.GetStat(cityInput);

            Assert.AreNotEqual(expected, act);

        }
    }
}
