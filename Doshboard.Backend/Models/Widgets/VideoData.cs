namespace Doshboard.Backend.Models.Widgets
{
    public class VideoData
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public ulong Likes { get; set; }
        public ulong Dislikes { get; set; }
        public ulong Views { get; set; }
        public ulong Comments { get; set; }

        public VideoData(string title, string thumbnail, ulong likes, ulong dislikes, ulong views, ulong comments)
        {
            Title = title;
            Thumbnail = thumbnail;
            Likes = likes;
            Dislikes = dislikes;
            Views = views;
            Comments = comments;
        }
    }
}
