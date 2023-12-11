using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace SQ.TermProject.myWeather.Services
{
    public class UserService : BaseService
    {

        public string getUserRole(string username)
        {
            string role;


            var roleId = base.DbContext.Users
                .Where(model => model.UserName == username)
                .Select(model => model.RoleId)
                .FirstOrDefault();


            role = base.DbContext.UserRoles.Where(model => model.Id == roleId).Select(model => model.Name).FirstOrDefault();


            return role;
        }

        public bool IsValidUser(string user, string pass)
        {

            string username = string.Empty, password = string.Empty;


                var passResult = base.DbContext.Users
                    .Where(model => model.UserName == user) 
                    .Select(model => model.Password) 
                    .FirstOrDefault(); 



                if (passResult != null)
                {
                    var saltResult = base.DbContext.Users
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
