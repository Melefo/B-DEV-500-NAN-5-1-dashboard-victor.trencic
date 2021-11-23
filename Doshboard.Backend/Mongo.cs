using Doshboard.Backend.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Doshboard.Backend
{
    public class Mongo
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<User> _userCollection;
        public Mongo(IConfiguration config)
        {
            _client = new MongoClient(config["Mongo:Client"]);
            _db = _client.GetDatabase(config["Mongo:Database"]);
            _userCollection = _db.GetCollection<User>("Users");
        }

        public List<User> GetUsers()
        {
            return _userCollection.Find(x => true).ToList();
        }
        public User GetUserFromUsername(string username)
        {
            var cursor = _userCollection.Find(x => x.Username == username);
            return cursor.SingleOrDefault();
        }
        public void CreateUser(User u)
        {
            _userCollection.InsertOne(new User(u.Username, u.Email, u.FirstName, u.LastName, u.Password));
        }
        public void DeleteUser(string id)
        {
            _userCollection.DeleteOne(x => x.Id == id);
        }

        public User GetFilteredUser(Expression<Func<User, bool>> filter)
        {
            return _userCollection.Find(filter).SingleOrDefault();
        }
    }

}
