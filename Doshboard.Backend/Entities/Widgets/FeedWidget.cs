using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display N last items from a RSS feed")]
    public class FeedWidget : Widget
    {
        public const string Name = "rss_feed";

        [WidgetParam]
        [BsonIgnore]
        public string Url
        {
            get => (string)Params["url"] ;
            set => Params["url"] = value;
        }

        [WidgetParam]
        [BsonIgnore]
        public int Items
        {
            get => (int)Params["items"];
            set => Params["items"] = value;
        }

        public FeedWidget() : base(Name, 3, 2)
        {
            Url = "https://news.google.com/rss";
            Items = 5;
        }
    }
}
