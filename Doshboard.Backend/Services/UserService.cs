using Doshboard.Backend.Entities;

namespace Doshboard.Backend.Services
{
    public class UserService
    {
        private Mongo _db;
        public UserService(Mongo db)
        {
            _db = db;
        }

        public List<User> GetUsers() => _db.GetUsers();

        public User GetUserFromUsername(string username) => _db.GetUserFromUsername(username);

        public void Create(User user) => _db.CreateUser(user);

        public void Delete(User user) => _db.DeleteUser(user);
    }
}
