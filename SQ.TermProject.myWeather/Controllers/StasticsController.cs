using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQ.TermProject.myWeather.Services;

namespace SQ.TermProject.myWeather.Controllers
{
    [ApiController]
    [Route("api/stats/[controller]")]
    public class StasticsController : Controller
    {
        private StatisticService stats;

        public StasticsController()
        {
            stats = new StatisticService();
        }

        [HttpPost("GetTop10Searches")]
        public async Task<IActionResult> GetTop10()
        {
            try
            {
                var list = stats.GetTop10SearchStats();

                return Ok(JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
