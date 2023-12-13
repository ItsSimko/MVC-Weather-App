using SQ.TermProject.myWeather.Models;
using System.Data;

namespace SQ.TermProject.myWeather.Services
{
    public class SettingsService : BaseService
    {
        public void UpdateUser(string name, string role)
        {
            var entityToUpdate = DbContext.Users.FirstOrDefault(e => e.UserName == name);
            var roleDb = DbContext.UserRoles.Where(e => e.Name == role).Select(e => e.Id).FirstOrDefault();

            entityToUpdate.RoleId = roleDb;

            DbContext.SaveChanges();
        }

        public void SetSiteHeader(string message, string type)
        {
            var entityToUpdate = DbContext.Alerts.FirstOrDefault();

            if (entityToUpdate == null)
            {
                entityToUpdate = new Alert
                {
                    AlertId=1,
                    AlertMsg=message,
                    AlertType=type
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

        public Alert GetSiteHeader()
        {
            var alert = DbContext.Alerts.FirstOrDefault();

            return alert;

        }


    }
}
