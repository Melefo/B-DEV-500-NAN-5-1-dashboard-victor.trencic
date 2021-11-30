using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Doshboard.Backend.Entities
{
    public class UserWidgets
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private init; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.ObjectId)]
        public string Owner { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Widgets { get; set; } = new();

        public UserWidgets(User user) =>
            Owner = user.Id;
        public UserWidgets(string userId) =>
            Owner = userId;
    }
}
