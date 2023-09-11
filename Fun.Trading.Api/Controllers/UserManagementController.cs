using Fun.Trading.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fun.Trading.Api.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a list of users (requires admin role).</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Authorize(Roles = "Admin")] // Requires admin role for access
        public IActionResult GetUsers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns user details by ID (requires admin or user role).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")] // Requires admin or user role for access
        public IActionResult GetUser(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("register")]
        public IActionResult RegisterUser(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs in a user and returns a JWT token for authentication
        /// </summary>
        /// <param name="request"></param>
        /// <returns>JWT token for authentication</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
