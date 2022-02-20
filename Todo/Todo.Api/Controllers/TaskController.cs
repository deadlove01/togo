using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.AppServices.Services;
using Todo.Contracts.Task;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IServiceManager _serviceManager;

        public TaskController(ILogger<TaskController> logger,
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

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetTasksByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var tasks = await _serviceManager.TaskService.GetTasksByUserIdAsync(userId, cancellationToken);
            return Ok(tasks);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTask(
            [FromBody] CreateTaskRequest createTaskRequest, CancellationToken cancellationToken)
        {
            var newTask = await _serviceManager.TaskService.CreateTaskAsync(createTaskRequest, cancellationToken);
            return Ok(newTask);
        }
        
        [HttpPost]
        [Route("{taskId}/update")]
        public async Task<IActionResult> UpdateTask(
            [FromRoute] Guid taskId,
            [FromBody] UpdateTaskRequest updateTaskRequest, CancellationToken cancellationToken)
        {
            var newTask = await _serviceManager.TaskService.UpdateTaskAsync(taskId, updateTaskRequest, cancellationToken);
            return Ok(newTask);
        }
        
    }
}