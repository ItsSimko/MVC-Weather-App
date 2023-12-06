using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;
using System.Text.Json;


namespace SQ.TermProject.myWeather.Controllers.UserAuth
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class Register : ControllerBase
    {
        private UserService userService = new UserService();

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
