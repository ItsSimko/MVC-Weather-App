using Microsoft.AspNetCore.Mvc;
using SQ.TermProject.myWeather.Services;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


namespace SQ.TermProject.myWeather.Controllers.UserAuth
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class Login : ControllerBase
    {
        private static readonly string secretKey = secretKey = PasswordService.GetSha256Hash(PasswordService.GenerateSalt(32));
        private UserService userService;
        private IConfiguration configuration;

        public Login()
        {

            userService = new UserService();
            configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        }

        [HttpPost(Name = "LoginUser")]
        public IActionResult LoginUser(string username, string password)
        {
            if (userService.IsValidUser(username, password))
            {
                string userRole = userService.getUserRole(username);
                string authToken = GenerateAuthToken(username, userRole);

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


        [HttpGet("helper")]

        public string GenerateAuthToken(string username, string role)
        {
            // https://medium.com/@vndpal/how-to-implement-jwt-token-authentication-in-net-core-6-ab7f48470f5c refrenced
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
{
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                // Add more claims if needed
            };

            var Sectoken = new JwtSecurityToken(configuration["Jwt:Issuer"],
              configuration["Jwt:Issuer"],
              claims: claim,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return token;
        }

    }
}
