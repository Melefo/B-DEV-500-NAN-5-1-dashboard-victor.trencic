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

        public WidgetHub(MongoService mongo, IHubContext<WidgetHub> hubContext)
        { 
            _mongo = mongo;
            _hubContext = hubContext;
        }

        public override Task OnConnectedAsync()
        {
            var widgets = _mongo.GetUserWidgets(Context.User!.Identity!.Name!).Widgets.Select(x => _mongo.GetWidget(x));
            var id = Context.ConnectionId;

            _clientJobs.Add(id, new());
            foreach (var widget in widgets)
            {
                string job = $"{id}#{widget.Id}";
                JobManager.AddJob(async () =>
                {
                    await _hubContext.Clients.Client(id).SendAsync(widget.Id, "update");
                    Console.WriteLine($"Event {widget.Id} to {id} sent");
                }, x => x.WithName(job).ToRunEvery(widget.Timer).Seconds());
                _clientJobs[id].Add(job);
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            foreach (var job in _clientJobs[Context.ConnectionId])
                JobManager.RemoveJob(job);
            _clientJobs.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
