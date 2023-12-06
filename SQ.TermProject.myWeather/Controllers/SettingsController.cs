using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;

namespace SQ.TermProject.myWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private SettingsService settingsService = new SettingsService();

        [HttpPost("GetUsers")]
        public ActionResult<IEnumerable<User>> GetUsers(string username)
        {
            var users = settingsService.DbContext.Users.Where(u => EF.Functions.Like(u.UserName, $"{username}%")).ToList();
            return Ok(users);
        }
    }
}
