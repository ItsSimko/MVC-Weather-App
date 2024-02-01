using SQ.TermProject.myWeather.Models;
using System.Data;

namespace SQ.TermProject.myWeather.Services
{
    public class SettingsService : BaseService
    {
        public void UpdateUser(string name, string role)
        {
            try 
            {
                var entityToUpdate = DbContext.Users.FirstOrDefault(e => e.UserName == name);
                var roleDb = DbContext.UserRoles.Where(e => e.Name == role).Select(e => e.Id).FirstOrDefault();

                entityToUpdate.RoleId = roleDb;

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LoggerService.Log($"Exception Thrown {ex.Message}");
            }

        }

        public void SetSiteHeader(string message, string type)
        {
            try
            {
                var entityToUpdate = DbContext.Alerts.FirstOrDefault();

                if (entityToUpdate == null)
                {
                    entityToUpdate = new Alert
                    {
                        AlertId = 1,
                        AlertMsg = message,
                        AlertType = type
                    };

                    DbContext.Alerts.Add(entityToUpdate);
                }
                else
                {
                    entityToUpdate.AlertMsg = message;
                    entityToUpdate.AlertType = type;
                }


                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LoggerService.Log($"Exception Thrown {ex.Message}");
            } 
        }

        public Alert GetSiteHeader()
        {
            try
            {
                var alert = DbContext.Alerts.FirstOrDefault();

                return alert;
            }
            catch (Exception ex)
            {
                LoggerService.Log($"Exception Thrown {ex.Message}");
                return null;
            }

        }


    }
}
