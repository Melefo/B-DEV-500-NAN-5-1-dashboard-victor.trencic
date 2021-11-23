using Doshboard.Backend.Entities;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Doshboard.Backend.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public List<User> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet("{username}")]
        public User GetUserFromUsername(string username)
        {
            return _service.GetUserFromUsername(username);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public void Create(User user)
        {
            _service.Create(user);
        }
        
        [HttpDelete]
        public void Delete(string id)
        {
            _service.Delete(id);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] User user)
        {
            (var token, user) = _service.Authenticate(user.Email, user.Username, user.Password);

            if (token == null)
                return Unauthorized();
            return Ok(new { token, user });
        }
    }

}
