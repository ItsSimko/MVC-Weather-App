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

        public void UpdateSiteHeader(string message, string type)
        {
            var entityToUpdate = DbContext.Alert.FirstOrDefault();

            entityToUpdate.AlertMsg = message;
            entityToUpdate.AlertType = type;

            DbContext.SaveChanges();
        }

        public Alert GetSiteHeader()
        {
            var alert = DbContext.Alert.FirstOrDefault();

            return alert;

        }


    }
}
