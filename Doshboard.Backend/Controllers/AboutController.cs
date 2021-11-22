using Doshboard.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    /// <summary>
    /// /about.json route controller
    /// </summary>
    [ApiController]
    [Route("[controller].json")]
    public class AboutController : ControllerBase
    {
        /// <summary>
        /// GET request on /about.json
        /// </summary>
        /// <returns>About model in json</returns>
        [HttpGet]
        public About Get()
        {
            string clientIp = Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;

            return new(clientIp);
        }
    }
}
