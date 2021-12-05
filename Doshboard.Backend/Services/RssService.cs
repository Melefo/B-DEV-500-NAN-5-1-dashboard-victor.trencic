using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Interfaces;
using Doshboard.Backend.Models.Widgets;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Doshboard.Backend.Services
{
    [ServiceName("RSS")]
    public class RssService : IService
    {
        private readonly MongoService _mongo;

        public static Type[] Widgets => new[]
        {
            typeof(FeedWidget)
        };

        public RssService(MongoService mongo) 
            => _mongo = mongo;

        public async Task<FeedData?> GetFeed(string id)
        {
            var widget = _mongo.GetWidget<FeedWidget>(id);
            if (widget == null || widget.Type != FeedWidget.Name)
                return null;

            using var reader = XmlReader.Create(widget.Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            var res = new FeedData(feed.Title.Text);

            foreach (var item in feed.Items)
            {
                if (--widget.Items < 0)
                    break;
                res.Items.Add(new(item.Title.Text, item.Summary.Text));
            }

            return res;
        }

        public void ConfigureFeed(string id, string? url, int? items)
        {
            var widget = _mongo.GetWidget<FeedWidget>(id);
            if (widget == null || widget.Type != FeedWidget.Name)
                return;

            if (url != null)
                widget.Url = url;
            if (items != null)
                widget.Items = (int)items;

            _mongo.SaveWidget(widget);
        }
    }
}
