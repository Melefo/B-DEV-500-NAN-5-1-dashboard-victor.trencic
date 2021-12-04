using Doshboard.Backend.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Doshboard.Backend.Entities.Widgets
{
    [WidgetInfo(Name, "Display N last items from a RSS feed")]
    public class FeedWidget : Widget
    {
        public const string Name = "rss_feed";

        public FeedWidget() : base(Name, 3, 2)
        {
        }

        [WidgetParam]
        [BsonIgnore]
        public string Url
        {
            get => Params.ContainsKey("url") ? (string)Params["url"] : "https://news.google.com/rss";
            set => Params["url"] = value;
        }

        [WidgetParam]
        [BsonIgnore]
        public int Items
        {
            get => Params.ContainsKey("items") ? (int)Params["items"] : 5;
            set => Params["items"] = value;
        }
    }
}
