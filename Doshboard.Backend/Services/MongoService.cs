using Doshboard.Backend.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
        private readonly IMongoCollection<User> _usersCollection;
        /// <summary>
        /// Mongo Widget Collection
        /// </summary>
        private readonly IMongoCollection<Widget> _widgetsCollection;
        /// <summary>
        /// Mongo User Widget Collection
        /// </summary>
        private readonly IMongoCollection<UserWidgets> _userWidgetsCollection;

        /// <summary>
        /// Mongo constructor
        /// </summary>
        /// <param name="config">Host configuration</param>
        public MongoService(IConfiguration config)
        {
            Console.WriteLine(config["Mongo:Client"]);
            _client = new MongoClient(config["Mongo:Client"]);
            _db = _client.GetDatabase(config["Mongo:Database"]);

            _usersCollection = _db.GetCollection<User>("Users");
            _widgetsCollection = _db.GetCollection<Widget>("Widgets");
            _userWidgetsCollection = _db.GetCollection<UserWidgets>("UserWidgets");
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of user</returns>
        public List<User> GetUsers() =>
            _usersCollection.Find(x => true).ToList();

        /// <summary>
        /// Get an user by its username
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>User account</returns>
        public User GetUser(string id) =>
            _usersCollection.Find(x => x.Id == id).SingleOrDefault();

        /// <summary>
        /// Get user by its authentication informations
        /// </summary>
        /// <param name="identifier">User username or email</param>
        /// <returns>User account</returns>
        public User GetUserByIdentifier(string identifier) =>
            _usersCollection.Find(x => x.Username == identifier || x.Email == identifier).SingleOrDefault();

        /// <summary>
        /// Create and insert user inside database
        /// </summary>
        /// <param name="u">User accoutn</param>
        public void CreateUser(User u) => 
            _usersCollection.InsertOne(u);

        /// <summary>
        /// Delete an user account inside database
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>true if successful</returns>
        public bool DeleteUser(string id)
        {
            var result = _usersCollection.DeleteOne(x => x.Id == id);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }

        /// <summary>
        /// Get services linked to an user
        /// </summary>
        /// <param name="user">User account</param>
        /// <returns>User services</returns>
        public UserWidgets GetUserWidgets(string userId)
        {
            var result = _userWidgetsCollection.Find(x => x.Owner == userId);

            return result.SingleOrDefault() ?? new(userId);
        }

        /// <summary>
        /// Save User widgets to database
        /// </summary>
        /// <param name="widgets">User widgets</param>
        /// <returns>True if successfully saved</returns>
        public bool SaveUserWidgets(UserWidgets widgets)
        {
            var result = _userWidgetsCollection.ReplaceOne(x => x.Id == widgets.Id, widgets, new ReplaceOptions 
            {
                IsUpsert = true
            });

            return result.IsAcknowledged && result.ModifiedCount == 1;
        }

        /// <summary>
        /// Get a widget
        /// </summary>
        /// <param name="widgetId">Widget id</param>
        /// <returns>Widget data</returns>
        public T GetWidget<T>(string widgetId) where T : Widget
            => _widgetsCollection.OfType<T>().Find(x => x.Id == widgetId).SingleOrDefault();

        /// <summary>
        /// Get a widget
        /// </summary>
        /// <param name="widgetId">Widget id</param>
        /// <returns>Widget data</returns>
        public Widget GetWidget(string widgetId) 
            => _widgetsCollection.Find(x => x.Id == widgetId).SingleOrDefault();

        public bool DeleteWidget(string id)
        {
            var result = _widgetsCollection.DeleteOne(x => x.Id == id);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }

        /// <summary>
        /// Save widget to database
        /// </summary>
        /// <param name="widget">Widget to save</param>
        /// <returns>True if successfully saved</returns>
        public bool SaveWidget(Widget widget)
        {
            var result = _widgetsCollection.ReplaceOne(x => x.Id == widget.Id, widget, new ReplaceOptions
            {
                IsUpsert = true
            });

            return result.IsAcknowledged && result.ModifiedCount == 1;
        }
    }

}
