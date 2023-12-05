using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace SQ.TermProject.myWeather.Services
{
    public class UserService : BaseService
    {
        public bool IsValidUser(string user, string pass)
        {

            string username = string.Empty, password = string.Empty;

            using (var context = base.DbContext)
            {
               
                var passResult = context.Users
                    .Where(model => model.UserName == user) 
                    .Select(model => model.Password) 
                    .FirstOrDefault(); 



                if (passResult != null)
                {
                    var saltResult = context.Users
                    .Where(model => model.UserName == user) 
                    .Select(model => model.Salt) 
                    .FirstOrDefault(); 
                    
                    username = user;

                    string hashedSample = PasswordService.GetSha256Hash(pass);

                    password = PasswordService.SaltHashBytes(hashedSample, saltResult);
                }

                return user == username && passResult == password;
            }

        }

        
    }
}
