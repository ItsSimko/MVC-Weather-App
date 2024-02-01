using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;
using System.Text.Json;


namespace SQ.TermProject.myWeather.Controllers.UserAuth
{
    /// <summary>
    /// Controller for user registration/authentication.
    /// </summary>
    [ApiController]
    [Route("api/auth/[controller]")]
    public class Register : ControllerBase
    {
        private UserService userService = new UserService();

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <param name="email">The email of the new user.</param>
        /// <returns>The IActionResult indicating success or failure of registration.</returns>
        [HttpPost(Name = "RegisterUser")]
        public IActionResult RegisterUser(string username, string password, string email)
        {
            string passwordHash = PasswordService.GetSha256Hash(password);
            string passwordSalt = PasswordService.GenerateSalt(password.Length);
            string computedPassword = PasswordService.SaltHashBytes(passwordHash, passwordSalt);



            // Check if the username already exists in the database
            if (userService.DbContext.Users.Any(u => u.UserName == username))
            {
                var response = new { success = false, msg = "Username already exists." };
                return Content(JsonSerializer.Serialize(response), "application/json");
            }

            if (userService.DbContext.Users.Any(u => u.Email == email))
            {
                var response = new { success = false, msg = "Email is in use." };
                return Content(JsonSerializer.Serialize(response), "application/json");
            }

            // Create and save the user

            var newUser = new User
            {
                UserName = username,
                Password = computedPassword,
                Salt = passwordSalt,
                Email = email,
                RoleId = new UserRole().Id
            };

            userService.DbContext.Users.Add(newUser);
            userService.DbContext.SaveChanges();

            var resp = new { success = true, msg = "Registration successful" };
            return Content(JsonSerializer.Serialize(resp), "application/json");
        }


    }
}
