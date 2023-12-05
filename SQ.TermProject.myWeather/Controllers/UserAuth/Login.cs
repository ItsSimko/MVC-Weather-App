using Microsoft.AspNetCore.Mvc;
using SQ.TermProject.myWeather.Services;
using System.Text.Json;


namespace SQ.TermProject.myWeather.Controllers.UserAuth
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class Login : ControllerBase
    {
        private UserService userService = new UserService();

        [HttpPost(Name = "LoginUser")]
        public IActionResult LoginUser(string username, string password)
        {
            if (userService.IsValidUser(username, password))
            {
                // Authentication successful
                // session identifier for the user
                string authToken = GenerateAuthToken();

                // Return a success response with the token 
                var resp = new { success = true, token = authToken };
                return Content(JsonSerializer.Serialize(resp), "application/json");

            }
            else
            {
                // Invalid credentials
                var resp = new { success = false, message = "Invalid username or password" };
                return Content(JsonSerializer.Serialize(resp), "application/json");
            }
        }



        public static string GenerateAuthToken()
        {

            return null;
        }

    }
}
