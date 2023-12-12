using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;

namespace SQ.TermProject.myWeather.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private SettingsService settingsService = new SettingsService();

        [HttpPost("GetUsers")]
        public ActionResult<IEnumerable<object>> GetUsers(string username)
        {

            object usersWithRoles = from u in settingsService.DbContext.Users
                                 join ur in settingsService.DbContext.UserRoles
                                 on u.RoleId equals ur.Id
                                 where u.UserName.StartsWith(username)

                                 select new
                                 {
                                     u.Id,
                                     u.UserName,
                                     ur.Name,
                                     u.Email
                                     // Include other properties you want to retrieve
                                 };


            return Ok(usersWithRoles);
        }

        [HttpPost("SetUser")]
        public ActionResult<IEnumerable<object>> SetUser(string username, string role)
        {

            var entityToUpdate = settingsService.DbContext.Users.FirstOrDefault(e => e.UserName == username);
            var roleDb = settingsService.DbContext.UserRoles.Where(e => e.Name == role).Select(e => e.Id).FirstOrDefault();

            entityToUpdate.RoleId = roleDb;

            settingsService.DbContext.SaveChanges();


            return Ok();
        }
    }
}
