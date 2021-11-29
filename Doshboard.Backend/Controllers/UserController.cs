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
        /// Get user by its username
        /// </summary>
        /// <param name="username">User username</param>
        /// <returns>User account</returns>
        [HttpGet("{username}")]
        public ActionResult<User> GetUserFromUsername(string username)
        {
            var user = _service.GetUserFromUsername(username);

            if (user == null)
                return NotFound();
            return user;
        }

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
            if (GetUsers().Count == 0)
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
    }

}
