using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display game informations")]
    public class GameWidget : Widget
    {
        public const string Name = "game_info";

        [WidgetParam]
        [BsonIgnore]
        public string GameName
        {
            get => (string)Params["name"];
            set => Params["name"] = value;
        }

        public GameWidget() : base(Name, 2, 2)
            => GameName = "Counter-Strike: Global Offensive";
    }
}
