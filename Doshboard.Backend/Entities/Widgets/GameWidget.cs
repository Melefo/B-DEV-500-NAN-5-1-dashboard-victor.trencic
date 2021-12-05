using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display game informations")]
    public class GameWidget : Widget
    {
        public const string Name = "game_info";

        public GameWidget() : base(Name, 2, 2)
        {
        }

        [WidgetParam]
        [BsonIgnore]
        public string GameName
        {
            get => Params.ContainsKey("name") ? (string)Params["name"] : "Counter-Strike: Global Offensive";
            set => Params["name"] = value;
        }
    }
}
