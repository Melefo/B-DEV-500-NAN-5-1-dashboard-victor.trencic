using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Interfaces;
using Doshboard.Backend.Models.Widgets;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Doshboard.Backend.Services
{
    /// <summary>
    /// RSS Service
    /// </summary>
    [ServiceName("RSS")]
    public class RssService : IService
    {
        private readonly MongoService _mongo;

        public static Type[] Widgets => new[]
        {
            typeof(FeedWidget)
        };

        /// <summary>
        /// RSS Service Constructor
        /// </summary>
        /// <param name="mongo"></param>
        public RssService(MongoService mongo) 
            => _mongo = mongo;

        /// <summary>
        /// Get RSS Feed From Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="MongoException"></exception>
        /// <exception cref="ApiException"></exception>
        public FeedData GetFeed(string id)
        {
            var widget = _mongo.GetWidget<FeedWidget>(id);
            if (widget == null)
                throw new MongoException("Widget not found");

            try
            {
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
            catch (HttpRequestException)
            {
                throw new ApiException("Invalid feed URL");
            }
        }

        /// <summary>
        /// Change widget configuration in db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="items"></param>
        /// <exception cref="MongoException"></exception>
        public void ConfigureFeed(string id, string? url, int? items)
        {
            var widget = _mongo.GetWidget<FeedWidget>(id);
            if (widget == null)
                throw new MongoException("Widget not found");

            if (url != null)
                widget.Url = url;
            if (items != null)
                widget.Items = (int)items;

            _mongo.SaveWidget(widget);
        }
    }
}
