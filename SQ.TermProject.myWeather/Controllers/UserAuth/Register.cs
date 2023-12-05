using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;
using System.Text.Json;


namespace SQ.TermProject.myWeather.Controllers.UserAuth
{
    [ApiController]
    [Route("[controller]")]
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
                return BadRequest("Username already exists.");
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

            return Ok("Registration successful");
        }


    }
}
