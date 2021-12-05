using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Services;
using FluentScheduler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    public class WidgetHub : Hub
    {
        private static Dictionary<string, List<string>> _clientJobs = new();

        private readonly MongoService _mongo;
        private readonly IHubContext<WidgetHub> _hubContext;
        private readonly WeatherService _weather;
        private readonly RssService _rss;
        private readonly SteamService _steam;
        private readonly CryptoService _crypto;
        private readonly YouTubeService _ytb;

        public WidgetHub(MongoService mongo, IHubContext<WidgetHub> hubContext, WeatherService weather, RssService rss, SteamService steam, CryptoService crypto, YouTubeService ytb)
        {
            _mongo = mongo;
            _hubContext = hubContext;
            _weather = weather;
            _rss = rss;
            _steam = steam;
            _crypto = crypto;
            _ytb = ytb;
        }

        public override Task OnConnectedAsync()
        {
            _clientJobs.Add(Context.ConnectionId, new());
            RegisterJobs(Context.ConnectionId, Context.User!.Identity!.Name!);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            foreach (var job in _clientJobs[Context.ConnectionId])
                JobManager.RemoveJob(job);
            _clientJobs.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        private async Task Job(Widget widget, string id, string userId)
        {
            try
            {
                switch (widget)
                {
                    case CityTempWidget:
                        var temp = await _weather.GetCityTemp(widget.Id);
                        await _hubContext.Clients.Client(id).SendAsync(widget.Id, temp);
                        break;
                    case FeedWidget:
                        var feed = _rss.GetFeed(widget.Id);
                        await _hubContext.Clients.Client(id).SendAsync(widget.Id, feed);
                        break;
                    case GameWidget:
                        var game = await _steam.GetGameData(widget.Id);
                        await _hubContext.Clients.Client(id).SendAsync(widget.Id, game);
                        break;
                    case RealTimeCryptoWidget:
                        var crypto = await _crypto.GetRealTimeCrypto(widget.Id);
                        await _hubContext.Clients.Client(id).SendAsync(widget.Id, crypto);
                        break;
                    case VideoWidget:
                        var video = await _ytb.GetVideoData(widget.Id, userId);
                        var videos = await _ytb.GetUserVideos(userId);
                        await _hubContext.Clients.Client(id).SendAsync(widget.Id, video, videos);
                        break;
                }
            }
            catch (MongoException)
            {

            }
            catch (ApiException)
            {

            }
            catch (WidgetException)
            {

            }
            catch (UserException)
            {

            }
        }

        private void RegisterJobs(string id, string userId)
        {
            var widgets = _mongo.GetUserWidgets(userId).Widgets.Select(x => _mongo.GetWidget(x));

            foreach (var widget in widgets)
            {
                if (widget == null)
                    continue;
                string job = $"{id}#{widget.Id}";
                JobManager.AddJob(async () => await Job(widget, id, userId),
                    x => x.WithName(job).ToRunEvery(widget.Timer).Minutes());
                _clientJobs[id].Add(job);
            }
        }

        public void UpdateTimer(string id, int minutes)
        {
            var widget = _mongo.GetWidget(id);
            string job = $"{Context.ConnectionId}#{id}";

            widget.Timer = minutes;
            JobManager.RemoveJob(job);
            JobManager.AddJob(async () => await Job(widget, id, Context.User!.Identity!.Name!),
                x => x.WithName(job).ToRunEvery(widget.Timer).Minutes());

            _mongo.SaveWidget(widget);
        }

        public void DeleteTimer(string id) 
            => JobManager.RemoveJob($"{Context.ConnectionId}#{id}");
    }
}
