using Doshboard.Backend.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Doshboard.Backend.Services
{
    /// <summary>
    /// User realted service
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Database access
        /// </summary>
        private readonly MongoService _db;
        /// <summary>
        /// JWT key
        /// </summary>
        private readonly string _key;

        public UserService(MongoService db, IConfiguration config)
        {
            _db = db;
            _key = config["JwtKey"];
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of User</returns>
        public List<User> GetUsers() => _db.GetUsers();

        /// <summary>
        /// Get an User by its username
        /// </summary>
        /// <param name="username">User username</param>
        /// <returns>User account</returns>
        public User GetUserFromUsername(string username) => _db.GetUserByUsername(username);

        /// <summary>
        /// Create an User account
        /// </summary>
        /// <param name="user">User informations</param>
        public void Create(User user) => _db.CreateUser(user);

        /// <summary>
        /// Deleta an User account
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>If successfully deleted</returns>
        public bool Delete(string id) => _db.DeleteUser(id);

        /// <summary>
        /// Authenticate User and give him a token
        /// </summary>
        /// <param name="username">User username or email</param>
        /// <param name="password">User password</param>
        /// <param name="user">User informations</param>
        /// <returns>JWT</returns>
        public string? Authenticate(string username, string password, out User user)
        {
            user = _db.GetUserByAuthentication(username, password);

            if (user == null)
                return null;

            JwtSecurityTokenHandler tokenHandler = new();

            var tokenKey = Encoding.UTF8.GetBytes(_key);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new(new Claim[]
                {
                    new(ClaimTypes.Email, user.Email),
                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}