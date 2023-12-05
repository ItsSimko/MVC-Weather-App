namespace SQ.TermProject.myWeather.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PermissionLevel { get; set; }

        public UserRole ()
        {
            Name = "User";
            PermissionLevel = 0;
        }
    }   
}
