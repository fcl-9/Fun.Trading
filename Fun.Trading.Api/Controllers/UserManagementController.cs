using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Fun.Trading.Api.DependencyInjectionConfigurations;
using Fun.Trading.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Fun.Trading.Api.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IAuthenticationApiClient _authClient;
        private readonly IOptions<AuthOptions> _authOptions;

        public UserManagementController(IAuthenticationApiClient authClient, IOptions<AuthOptions> authOptions)
        {
            _authClient = authClient;
            _authOptions = authOptions;
        }

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
        /// Temporary to be replaced by SPA
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            var userRequest = new SignupUserRequest()
            {
                ClientId = _authOptions.Value.ClientId,
                Email = request.Email,
                Password = request.Password,
                Connection = _authOptions.Value.Connection
            };

            var authUser = await _authClient.SignupUserAsync(userRequest);

            return Ok(authUser);
        }

        /// <summary>
        /// Logs in a user and returns a JWT token for authentication
        /// Temporary to be replaced by SPA
        /// </summary>
        /// <param name="request"></param>
        /// <returns>JWT token for authentication</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var tokenRequest = new ResourceOwnerTokenRequest
            {
                ClientId = _authOptions.Value.ClientId,
                ClientSecret = _authOptions.Value.ClientSecret,
                Scope = "openid profile",
                Realm = _authOptions.Value.Connection,
                Username = request.Username, 
                Password = request.Password
            };

            var tokenResponse = await _authClient.GetTokenAsync(tokenRequest);

            return Ok(new { tokenResponse.AccessToken });
        }
    }
}
