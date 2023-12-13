using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQ.TermProject.myWeather.Services;

namespace SQ.TermProject.myWeather.Controllers
{
    /// <summary>
    /// Controller for retrieving statistics related to weather searches.
    /// </summary>
    [ApiController]
    [Route("api/stats/[controller]")]
    public class StasticsController : Controller
    {
        private StatisticService stats;

        /// <summary>
        /// Initializes a new instance of the StasticsController class.
        /// </summary>
        public StasticsController()
        {
            stats = new StatisticService();
        }

        /// <summary>
        /// Retrieves the top 10 search statistics.
        /// </summary>
        /// <returns>The IActionResult containing the top 10 search statistics if successful; otherwise, an error response.</returns>
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
