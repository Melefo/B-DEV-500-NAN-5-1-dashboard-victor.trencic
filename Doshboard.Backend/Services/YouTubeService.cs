using Doshboard.Backend.Attributes;
using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Interfaces;
using Doshboard.Backend.Models.Widgets;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using static Google.Apis.YouTube.v3.YouTubeService;

namespace Doshboard.Backend.Services
{
    /// <summary>
    /// Youtube Service
    /// </summary>
    [ServiceName("YouTube")]
    public class YouTubeService : IService
    {
        private readonly MongoService _mongo;
        private readonly string _googleId;
        private readonly string _googleSecret;
        private readonly string _googleKey;

        public static Type[] Widgets => new[]
        {
            typeof(VideoWidget)
        };

        /// <summary>
        /// Youtube Service Constructor
        /// </summary>
        /// <param name="mongo"></param>
        /// <param name="config"></param>
        public YouTubeService(MongoService mongo, IConfiguration config)
        {
            _mongo = mongo;
            _googleId = config["Google:ClientId"];
            _googleSecret = config["Google:ClientSecret"];
            _googleKey = config["Google:ApiKey"];
        }

        /// <summary>
        /// Create a Youtube Widget from a Google account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        private Google.Apis.YouTube.v3.YouTubeService CreateYouTube(GoogleAccount account)
        {
            return new(new BaseClientService.Initializer()
            {
                ApiKey = _googleKey,
                HttpClientInitializer = new UserCredential(new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = _googleId,
                        ClientSecret = _googleSecret
                    },
                    Scopes = new[] { Scope.YoutubeReadonly }
                }), account.UserId, new TokenResponse()
                {
                    RefreshToken = account.RefreshToken,
                })
            });
        }

        /// <summary>
        /// Get Data from Video with User and Video ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="UserException"></exception>
        /// <exception cref="MongoException"></exception>
        /// <exception cref="ApiException"></exception>
        public async Task<VideoData> GetVideoData(string id, string userId)
        {
            var user = _mongo.GetUser(userId);
            if (user.Google == null)
                throw new UserException("You must have your Google Account associated to use this widget");

            var ytb = CreateYouTube(user.Google);

            var widget = _mongo.GetWidget<VideoWidget>(id);
            if (widget == null)
                throw new MongoException("Widget not found");

            var videoRequest = ytb.Videos.List("statistics, snippet");
            videoRequest.Id = widget.VideoId;

            var video = await videoRequest.ExecuteAsync();
            if (video.Items.Count != 1)
                throw new ApiException("No video found");

            return new(video.Items[0].Snippet.Title, video.Items[0].Snippet.Thumbnails.Maxres?.Url ?? video.Items[0].Snippet.Thumbnails.High.Url,
                video.Items[0].Statistics.LikeCount.GetValueOrDefault(), video.Items[0].Statistics.DislikeCount.GetValueOrDefault(),
                video.Items[0].Statistics.ViewCount.GetValueOrDefault(), video.Items[0].Statistics.CommentCount.GetValueOrDefault());
        }

        /// <summary>
        /// Configure 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="videoId"></param>
        /// <exception cref="MongoException"></exception>
        public void ConfigureVideo(string id, string? videoId)
        {
            var widget = _mongo.GetWidget<VideoWidget>(id);
            if (widget == null)
                throw new MongoException("Widget not found");

            if (videoId != null)
                widget.VideoId = videoId;
            _mongo.SaveWidget(widget);
        }

        /// <summary>
        /// Get Video by User ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="UserException"></exception>
        public async Task<Dictionary<string, string>> GetUserVideos(string userId)
        {
            var user = _mongo.GetUser(userId);
            if (user.Google == null)
                throw new UserException("You must have your Google Account associated to use this widget");

            var ytb = CreateYouTube(user.Google);
            Dictionary<string, string> videos = new();

            var channelsRequest = ytb.Channels.List("contentDetails");
            channelsRequest.Mine = true;

            var channels = await channelsRequest.ExecuteAsync();
            foreach (var channel in channels.Items)
            {
                string next = string.Empty;

                while (next != null)
                {
                    var uploadsRequest = ytb.PlaylistItems.List("snippet");
                    uploadsRequest.MaxResults = 50;
                    uploadsRequest.PlaylistId = channel.ContentDetails.RelatedPlaylists.Uploads;
                    uploadsRequest.PageToken = next;

                    var uploads = await uploadsRequest.ExecuteAsync();

                    foreach (var upload in uploads.Items)
                        videos.Add(upload.Snippet.ResourceId.VideoId, upload.Snippet.Title);

                    next = uploads.NextPageToken;
                }
            }

            return videos;
        }
    }
}