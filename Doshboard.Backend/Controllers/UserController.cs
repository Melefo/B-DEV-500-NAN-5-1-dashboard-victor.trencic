using Doshboard.Backend.Entities;
using Doshboard.Backend.Models;
using Doshboard.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Doshboard.Backend.Controllers
{
    /// <summary>
    /// user information/auth route
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service) =>
            _service = service;

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of User</returns>
        [HttpGet]
        public List<User> GetUsers() =>
            _service.GetUsers();

        /// <summary>
        /// Register an user to database
        /// </summary>
        /// <param name="form">User informations</param>
        /// <returns>return newly created if succesfully registered</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<User> Create([FromBody] RegisterForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = new User(form.Username, form.Email, form.FirstName, form.LastName, form.Password);
            if (_service.GetUsers().Count == 0)
                user.Role = "Admin";
            _service.Create(user);
            return Created("", user);
        }
        
        /// <summary>
        /// Delete an user from database
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Request Accepted</returns>
        [HttpDelete("delete")]
        public ActionResult Delete([BindRequired] string id)
        {
            _service.Delete(id);
            return Accepted();
        }

        /// <summary>
        /// Login user to API
        /// </summary>
        /// <param name="form">User informations</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var token = _service.Authenticate(form.Username, form.Password, out var user);

            if (token == null)
                return Unauthorized();
            return Ok(new { token, user });
        }

        [HttpPatch("promote")]
        public ActionResult PromoteUser(string id)
        {
            _service.Promote(id);

            return Ok();
        }
    }

}
