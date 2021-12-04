using Doshboard.Backend.Entities;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly WidgetService _service;

        public WidgetController(WidgetService service)
            => _service = service;

        [HttpGet]
        public ActionResult<List<Widget>> GetUserWidgets()
        {
            List<Widget> widgets = new();

            foreach (var widget in _service.GetUserWidgets(User.Identity!.Name!).Widgets)
                widgets.Add(_service.GetWidget(widget));

            return widgets;
        }

        [HttpGet("ws")]
        public async Task<ActionResult> WebSocket()
        {
            var ws = ControllerContext.HttpContext.WebSockets;

            if (!ws.IsWebSocketRequest || ws.WebSocketRequestedProtocols.Count != 2)
                return BadRequest();

            var websocket = await ws.AcceptWebSocketAsync(ws.WebSocketRequestedProtocols[0]);
            while (true)
            {
                if (websocket.State != WebSocketState.Open)
                    break;
                var bytes = Encoding.UTF8.GetBytes(""); //Here send widget data
                await websocket.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
                await websocket.ReceiveAsync(bytes, CancellationToken.None);
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult AddWidget(string type)
        {
            var widget = _service.NewUserWidget(User.Identity!.Name!, type);
            return Created("", widget);
        }

        [HttpDelete]
        public ActionResult DeleteWidget(string id)
        {
            _service.DeleteUserWidget(User.Identity!.Name!, id);
            return Accepted();
        }

        [HttpPatch("update")]
        public ActionResult UpdateWidget(string id, int x, int y)
        {
            Widget widget = _service.GetWidget(id);
            widget.X = x;
            widget.Y = y;
            _service.UpdateWidget(widget);
            return Ok();
        }
    }
}
