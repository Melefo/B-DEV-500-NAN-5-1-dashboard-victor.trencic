using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widget;
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

        [Authorize]
        [HttpGet]
        public ActionResult<List<AWidget>> GetUserWidgets()
        {
            List<AWidget> widgets = new();

            foreach (var widget in _service.GetUserWidgets(User.Identity!.Name!).Widgets)
                widgets.Add(_service.GetWidget(widget));

            return widgets;
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddWidget(WidgetType type)
        {
            var widget = _service.NewUserWidget(User.Identity!.Name!, type);
            return Created("", widget);
        }
    }
}
