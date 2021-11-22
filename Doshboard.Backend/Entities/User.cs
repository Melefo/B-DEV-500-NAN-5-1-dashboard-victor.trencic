using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; private init; } = ObjectId.GenerateNewId();
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public User(string username, string firstName, string lastName, string password)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        
    }
}
