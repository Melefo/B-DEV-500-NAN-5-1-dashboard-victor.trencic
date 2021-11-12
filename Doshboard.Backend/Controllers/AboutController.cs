using Doshboard.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
    [ApiController]
    [Route("[controller].json")]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public AboutModel Get()
        {
            string ClientIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return new AboutModel
            {
                Client = new()
                {
                    Host = ClientIp,
                },
                Server = new()
                {
                    CurrentTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                }
            };


        }
    }
}
