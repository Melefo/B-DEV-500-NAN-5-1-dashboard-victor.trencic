namespace Doshboard.Backend.Models.Widgets
{
    public class FeedItem
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public FeedItem(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }

    public class FeedData
    {
        public string Name { get; set; }
        public List<FeedItem> Items {get;set;} = new();

        public FeedData(string name) 
            => Name = name;
    }
}
