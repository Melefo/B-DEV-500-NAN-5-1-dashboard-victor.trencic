using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display realtime video informations")]
    public class VideoWidget : Widget
    {
        public const string Name = "video";

        public VideoWidget() : base(Name, 2, 2)
        {
        }

        [WidgetParam]
        [BsonIgnore]
        public string VideoId
        {
            get => Params.ContainsKey("videoId") ? (string)Params["videoId"] : "jNQXAC9IVRw";
            set => Params["videoId"] = value;
        }
    }
}
