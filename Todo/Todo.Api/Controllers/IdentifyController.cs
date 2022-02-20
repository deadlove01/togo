using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.AppServices.Services;

namespace Todo.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class IdentifyController : ControllerBase
    {
        private readonly ILogger<IdentifyController> _logger;
        private readonly IServiceManager _serviceManager;

        public IdentifyController(ILogger<IdentifyController> logger,
            IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var tasks = await _serviceManager.TaskService.GetTasksAsync(cancellationToken);
            return Ok(tasks);
        }
    }
}