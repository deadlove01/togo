using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Todo.Api.Configs;
using Todo.AppServices;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IOptions<MembershipConfigs> _options;
        private readonly IServiceManager _serviceManager;

        public UserController(ILogger<UserController> logger,
            IOptions<MembershipConfigs> options,
            IServiceManager serviceManager)
        {
            _logger = logger;
            _options = options;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToke)
        {
            var users = await _serviceManager.UserService.GetAllUsersAsync(cancellationToke);
            return Ok(users);
        }
    }
}