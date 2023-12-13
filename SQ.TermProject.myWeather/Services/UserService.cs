using Microsoft.EntityFrameworkCore;
using SQ.TermProject.myWeather.Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace SQ.TermProject.myWeather.Services
{
    /// <summary>
    /// Service class for user-related tasks.
    /// </summary>
    public class UserService : BaseService
    {
        /// <summary>
        /// Retrieves the role of a user based on their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The role of the user.</returns>
        public string getUserRole(string username)
        {
            try 
            {
                string role;


                var roleId = base.DbContext.Users
                    .Where(model => model.UserName == username)
                    .Select(model => model.RoleId)
                    .FirstOrDefault();


                role = base.DbContext.UserRoles.Where(model => model.Id == roleId).Select(model => model.Name).FirstOrDefault();


                return role;
            }
            catch (Exception ex)
            {
                LoggerService.Log("Exception Message: "+ ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Checks if the provided user credentials are valid.
        /// </summary>
        /// <param name="user">The username to validate.</param>
        /// <param name="pass">The password to validate.</param>
        /// <returns>True if the user is valid, otherwise false.</returns>
        public bool IsValidUser(string user, string pass)
        {
            try
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
            catch (Exception ex)
            {
                LoggerService.Log("Exception Message: " + ex.Message);
                return false;
            }
        }

    }
}
