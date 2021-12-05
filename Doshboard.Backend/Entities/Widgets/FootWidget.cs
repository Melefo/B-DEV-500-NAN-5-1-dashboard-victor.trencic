using Doshboard.Backend.Attributes;
using Doshboard.Backend.Services;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display Competition")]
    public class FootWidget : Widget
    {
        public const string Name = "foot_competitions";

        public FootWidget() : base(Name, 2, 2)
        {
        }

        [WidgetParam]
        [BsonIgnore]
        public string Id
        {   
            get => Params.ContainsKey("id") ? (string)Params["id"] : "2015"; //2015 == Ligue 1
            set => Params["id"] = value;
        }
    }
}
