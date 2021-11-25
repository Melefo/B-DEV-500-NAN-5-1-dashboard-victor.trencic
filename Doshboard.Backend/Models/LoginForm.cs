using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models
{
    /// <summary>
    /// Login form data
    /// </summary>
    public class LoginForm
    {
        /// <summary>
        /// User username or email
        /// </summary>
        [MinLength(2)]
        [MaxLength(256)]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [MinLength(2)]
        [MaxLength(256)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// LoginForm constructor
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public LoginForm(string username,  string password)
        {
            Username = username;
            Password = password;
        }
    }
}
