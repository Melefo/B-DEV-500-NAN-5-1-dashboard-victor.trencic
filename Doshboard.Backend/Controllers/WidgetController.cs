using Doshboard.Backend.Entities;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly WidgetService _service;

        public WidgetController(WidgetService service) =>
            _service = service;

        [HttpGet]
        public ActionResult<List<Widget>> GetUserWidgets()
        {
            List<Widget> widgets = new();

            foreach (var widget in _service.GetUserWidgets(User.Identity!.Name!).Widgets)
                widgets.Add(_service.GetWidget(widget));

            return widgets;
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
