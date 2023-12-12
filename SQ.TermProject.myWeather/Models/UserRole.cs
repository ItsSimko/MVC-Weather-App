namespace SQ.TermProject.myWeather.Models
{
    /// <summary>
    /// Represents a user role in the system.
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permission level associated with the user role.
        /// </summary>
        public int PermissionLevel { get; set; }

        /// <summary>
        /// Initializes a default instance of the UserRole class with predefined values.
        /// </summary>
        public UserRole ()
        {
            Id = 1;
            Name = "User";
            PermissionLevel = 1;
        }
    }   
}
