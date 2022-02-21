using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Todo.Api.Configs;
using Todo.AppServices.Services;
using Todo.Contracts.User;

namespace Todo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public UserController(
            IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToke)
        {
            var users = await _serviceManager.UserService.GetAllUsersAsync(cancellationToke);
            return Ok(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUser(
            [FromBody] CreateUserRequest createUserRequest,
            CancellationToken cancellationToke)
        {
            var users = await _serviceManager.UserService.CreateUserAsync(createUserRequest, cancellationToke);
            return Ok(users);
        }
        
        [AllowAnonymous]    
        [HttpPost]   
        [Route("login")]
        public async Task<IActionResult> Login(
            [FromServices] IAuthService authService,
            [FromBody] LoginRequest loginRequest,
            CancellationToken cancellationToken)
        {
            IActionResult response = Unauthorized();
            var user = await _serviceManager.UserService.GetUserByUsernameAsync(loginRequest.Username,
                loginRequest.Password, cancellationToken);
    
            if (user != null)    
            {    
                var tokenString = authService.GenerateJWT(user.Id);     
                response = Ok(new { token = tokenString });    
            }    
    
            return response; 
        }
    }
}