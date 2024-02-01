using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;

namespace SQ.TermProject.myWeather.Controllers
{
    /// <summary>
    /// Controller for managing application settings.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private SettingsService settingsService = new SettingsService();

        /// <summary>
        /// Retrieves users based on the provided username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>The ActionResult containing user details with roles if successful; otherwise, an error response.</returns>
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

        /// <summary>
        /// Sets the role for a specific user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>The ActionResult indicating success or failure.</returns>
        [HttpPost("SetUser")]
        public ActionResult<IEnumerable<object>> SetUser(string username, string role)
        {

            settingsService.UpdateUser(username, role);


            return Ok();
        }

        /// <summary>
        /// Retrieves the site header information.
        /// </summary>
        /// <returns>The ActionResult containing the site header if successful; otherwise, an error response.</returns>
        [HttpPost("GetHeader")]
        public ActionResult<IEnumerable<object>> GetHeader()
        {
            return Ok(settingsService.GetSiteHeader());
        }

        /// <summary>
        /// Sets the site header message and type.
        /// </summary>
        /// <param name="msg">The message to set in the site header.</param>
        /// <param name="type">The type of the message (e.g., informational, warning).</param>
        /// <returns>The ActionResult indicating success or failure.</returns>
        [HttpPost("SetHeader")]
        [Authorize(Roles = "Admin,Superadmin")]
        public ActionResult<IEnumerable<object>> SetHeader(string msg, string type)
        {
            settingsService.SetSiteHeader(msg, type);
            return Ok();
        }
    }
}
