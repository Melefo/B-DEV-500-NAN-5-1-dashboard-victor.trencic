using Doshboard.Backend.Entities;
using Doshboard.Backend.Utilities;
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
        /// Create an User account
        /// </summary>
        /// <param name="user">User informations</param>
        public void Create(User user)
        {
            if (_db.GetUserByIdentifier(user.Email) != null || _db.GetUserByIdentifier(user.Username) != null)
            {
                return;
            }
            user.Password = PasswordHash.HashPassword(user.Password);
            _db.CreateUser(user);
        }

        /// <summary>
        /// Deleta an User account
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>If successfully deleted</returns>
        public bool Delete(string id) => _db.DeleteUser(id);

        /// <summary>
        /// Promote an User to Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Promote(string id)
        {
            User user = _db.GetUser(id);
            user.Role = user.Role == "Admin" ? "User" : "Admin";

            return _db.UserSave(user);
        }

        /// <summary>
        /// Authenticate User and give him a token
        /// </summary>
        /// <param name="username">User username or email</param>
        /// <param name="password">User password</param>
        /// <param name="user">User informations</param>
        /// <returns>JWT</returns>
        public string? Authenticate(string username, string password, out User? user)
        {
            var found = _db.GetUserByIdentifier(username);
            user = default;

            if (found == null)
                return null;
            if (!PasswordHash.VerifyPassword(password, found.Password))
                return null;

            user = found;
            JwtSecurityTokenHandler tokenHandler = new();

            var tokenKey = Encoding.UTF8.GetBytes(_key);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new(new Claim[]
                {
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.Role, user.Role),
                    new(ClaimTypes.Name, user.Id),
                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}