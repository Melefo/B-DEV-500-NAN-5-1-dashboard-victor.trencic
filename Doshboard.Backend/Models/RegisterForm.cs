using System.ComponentModel.DataAnnotations;

namespace Doshboard.Backend.Models
{
    /// <summary>
    /// Register form data
    /// </summary>
    public class RegisterForm
    {
        /// <summary>
        /// User username
        /// </summary>
        [MinLength(2)]
        [MaxLength(256)]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User last name
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [MinLength(2)]
        [MaxLength(256)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// RegisterForm constructor
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="password">Password</param>
        public RegisterForm(string username, string email, string firstName, string lastName, string password)
        {
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
