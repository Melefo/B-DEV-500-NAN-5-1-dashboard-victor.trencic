using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display realtime video informations")]
    public class VideoWidget : Widget
    {
        public const string Name = "video";

        [WidgetParam]
        [BsonIgnore]
        public string VideoId
        {
            get => (string)Params["videoId"];
            set => Params["videoId"] = value;
        }

        public VideoWidget() : base(Name, 2, 2)
            => VideoId = "jNQXAC9IVRw";
    }
}
