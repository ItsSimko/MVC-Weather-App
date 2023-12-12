namespace SQ.TermProject.myWeather.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public int RoleId { get; set; } = 1;

    }
}
