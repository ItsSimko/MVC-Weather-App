using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,Superadmin")]
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

            settingsService.UpdateUser(username, role);


            return Ok();
        }

        [HttpPost("GetHeader")]
        public ActionResult<IEnumerable<object>> GetHeader()
        {
            return Ok(settingsService.GetSiteHeader());
        }

        [HttpPost("SetHeader")]
        [Authorize(Roles = "Admin,Superadmin")]
        public ActionResult<IEnumerable<object>> SetHeader(string msg, string type)
        {
            settingsService.SetSiteHeader(msg, type);
            return Ok();
        }
    }
}
