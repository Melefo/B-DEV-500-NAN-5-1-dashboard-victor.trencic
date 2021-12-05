using Doshboard.Backend.Attributes;
using Doshboard.Backend.Services;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display Competition")]
    public class FootWidget : Widget
    {
        public const string Name = "foot_competition";

        public FootWidget() : base(Name, 2, 2) 
            => CompetitionId = "2015";

        [WidgetParam]
        [BsonIgnore]
        public string CompetitionId
        {   
            get => (string)Params["id"]; //2015 == Ligue 1
            set => Params["id"] = value;
        }
    }
}
