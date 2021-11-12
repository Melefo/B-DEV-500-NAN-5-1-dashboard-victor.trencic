using Doshboard.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [ApiController]
    [Route("[controller].json")]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public About Get()
        {
            string clientIp = Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;

            return new(clientIp);
        }
    }
}
