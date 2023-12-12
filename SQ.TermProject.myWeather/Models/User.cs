namespace SQ.TermProject.myWeather.Models
{
    /// <summary>
    /// Represents a user with authentication credentials and associated information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the salt used for password hashing.
        /// </summary>
        public string? Salt { get; set; }

        /// <summary>
        /// Gets or sets the role identifier associated with the user (defaults to 1).
        /// </summary>
        public int RoleId { get; set; } = 1;

    }
}
