using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Doshboard.Backend.Entities
{
    public class Widget
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private init; } = ObjectId.GenerateNewId().ToString();

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Height { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }

        public Dictionary<string, object> Params { get; set; } = new();

        [BsonIgnore]
        public int Timer
        {
            get => Params.ContainsKey("timer") ? (int)Params["timer"] : 5;
            set => Params["timer"] = value;
        }

        public Widget(string type, int height, int width)
        { 
            Type = type;
            Height = height;
            Width = width;
        }

        [JsonConstructor]
        public Widget(string id, int x, int y, int height, int width, string type, Dictionary<string, object> @params)
        {
            Id = id;
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Type = type;
            Params = @params;
        }
    }
}
