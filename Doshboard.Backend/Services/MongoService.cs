using Doshboard.Backend.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Doshboard.Backend
{
    /// <summary>
    /// Mongo service database wrapper
    /// </summary>
    public class MongoService
    {
        /// <summary>
        /// Mongo client
        /// </summary>
        private readonly MongoClient _client;
        /// <summary>
        /// Mongo Database
        /// </summary>
        private readonly IMongoDatabase _db;
        /// <summary>
        /// Mongo User Collection
        /// </summary>
        private readonly IMongoCollection<User> _userCollection;

        /// <summary>
        /// Mongo constructor
        /// </summary>
        /// <param name="config">Host configuration</param>
        public MongoService(IConfiguration config)
        {
            Console.WriteLine(config["Mongo:Client"]);
            _client = new MongoClient(config["Mongo:Client"]);
            _db = _client.GetDatabase(config["Mongo:Database"]);
            _userCollection = _db.GetCollection<User>("Users");
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of user</returns>
        public List<User> GetUsers() =>
            _userCollection.Find(x => true).ToList();

        /// <summary>
        /// Get an user by its username
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>User account</returns>
        public User GetUserByUsername(string username) =>
            _userCollection.Find(x => x.Username == username).SingleOrDefault();

        /// <summary>
        /// Get user by its authentication informations
        /// </summary>
        /// <param name="username">User username or email</param>
        /// <param name="password">User password</param>
        /// <returns>User account</returns>
        public User GetUserByAuthentication(string username, string password) =>
            _userCollection.Find(x => (x.Username == username || x.Email == username) && x.Password == password).SingleOrDefault();

        /// <summary>
        /// Create and insert user inside database
        /// </summary>
        /// <param name="u">User accoutn</param>
        public void CreateUser(User u) => 
            _userCollection.InsertOne(u);

        /// <summary>
        /// Delete an user account inside database
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>true if successful</returns>
        public bool DeleteUser(string id)
        {
            var result = _userCollection.DeleteOne(x => x.Id == id);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }

}
