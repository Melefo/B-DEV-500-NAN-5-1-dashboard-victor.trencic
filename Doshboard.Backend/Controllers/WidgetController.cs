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
    /// <summary>
    /// Widget Controller route
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly WidgetService _service;

        public WidgetController(WidgetService service)
            => _service = service;
        /// <summary>
        /// Get Widget of an User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Widget>> GetUserWidgets()
        {
            List<Widget> widgets = new();

            foreach (var widget in _service.GetUserWidgets(User.Identity!.Name!).Widgets)
                widgets.Add(_service.GetWidget(widget));

            return widgets;
        }
        /// <summary>
        /// Add a widget for an user by it's type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete a widget for an user by it's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult DeleteWidget(string id)
        {
            _service.DeleteUserWidget(User.Identity!.Name!, id);
            return Accepted();
        }
        /// <summary>
        /// Update a widget position (x,y) for an user by it's ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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
