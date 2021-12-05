using Doshboard.Backend.Entities;
using Doshboard.Backend.Exceptions;
using Doshboard.Backend.Services;
using FluentScheduler;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Widget>> GetUserWidgets()
        {
            List<Widget> widgets = new();

            foreach (var widget in _service.GetUserWidgets(User.Identity!.Name!).Widgets)
                widgets.Add(_service.GetWidget(widget));

            return widgets;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddWidget(string type)
        {
            try
            {
                return Created("", _service.NewUserWidget(User.Identity!.Name!, type));
            }
            catch (NotImplementedException)
            {
                return BadRequest(new { error = "Invalid widget" });
            }
            catch (UserException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult DeleteWidget(string id)
        {
            _service.DeleteUserWidget(User.Identity!.Name!, id);
            return Accepted();
        }

        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult UpdateWidget(string id, int x, int y)
        {
            Widget widget = _service.GetWidget(id);
            widget.X = x;
            widget.Y = y;
            _service.UpdateWidget(widget);
            return Accepted();
        }
    }
}
