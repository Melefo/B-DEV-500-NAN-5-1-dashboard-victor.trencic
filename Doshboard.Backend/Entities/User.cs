using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Database User-Object Id
        /// </summary>
        //[JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private init; } = ObjectId.GenerateNewId().ToString();
        /// <summary>
        /// User username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="password">Password</param>
        public User(string username, string email, string firstName, string lastName, string password)
        {
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
