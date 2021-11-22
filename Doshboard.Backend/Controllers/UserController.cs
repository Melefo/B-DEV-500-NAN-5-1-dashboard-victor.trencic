using Doshboard.Backend.Entities;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doshboard.Backend.Controllers
{
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

        [HttpPost]
        public void Create(User user)
        {
            _service.Create(user);
        }

        [HttpDelete]
        public void Delete(User user)
        {
            _service.Delete(user);
        }
    }
}
