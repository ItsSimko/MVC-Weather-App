namespace SQ.TermProject.myWeather.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PermissionLevel { get; set; }

        public UserRole ()
        {
            Id = 1;
            Name = "User";
            PermissionLevel = 1;
        }
    }   
}
