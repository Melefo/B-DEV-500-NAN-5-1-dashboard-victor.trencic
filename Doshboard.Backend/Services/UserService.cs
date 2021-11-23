using Doshboard.Backend.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Doshboard.Backend.Services
{
    public class UserService
    {
        private Mongo _db;
        private readonly string key;
        public UserService(Mongo db, IConfiguration config)
        {
            _db = db;
            key = config["JwtKey"];
        }

        public List<User> GetUsers() => _db.GetUsers();

        public User GetUserFromUsername(string username) => _db.GetUserFromUsername(username);

        public void Create(User user) => _db.CreateUser(user);

        public void Delete(string id) => _db.DeleteUser(id);

        public (string, User) Authenticate(string email, string username, string password)
        {
            var user = _db.GetFilteredUser(x => (x.Email == email || x.Username == username) && x.Password == password);

            if (user == null)
                return (null, null);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials (
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256
            )};

            var token = tokenHandler.CreateToken(tokenDescriptor);     

            return (tokenHandler.WriteToken(token), user);
        }
    }
}
