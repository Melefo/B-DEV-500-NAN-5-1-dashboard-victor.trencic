using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Doshboard.Backend.Entities
{
    public class UserServices
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private init; } = ObjectId.GenerateNewId().ToString();

        public MongoDBRef Owner { get; set; }
        public Weather? Weather { get; set; }

        public UserServices(User user) => 
            Owner = new MongoDBRef("User", user.Id);
        public UserServices(string userId) =>
            Owner = new MongoDBRef("User", userId);
    }

    public enum UnitType
    {
        Celsius,
        Fahrenheit
    }

    public class Weather
    {
        public string City { get; set; } = "Paris";
        public UnitType Unit { get; set; } = UnitType.Celsius;
    }
}
