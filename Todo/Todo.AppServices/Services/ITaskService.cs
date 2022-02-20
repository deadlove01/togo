using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Contracts.Task;

namespace Todo.AppServices.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponse>> GetTasksAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskResponse>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<TaskResponse> CreateTaskAsync(CreateTaskRequest createTaskRequest, CancellationToken cancellationToken = default);
        Task<TaskResponse> UpdateTaskAsync(Guid id, UpdateTaskRequest updateTaskRequest, CancellationToken cancellationToken = default);
        Task<TaskResponse> RemoveTaskAysnc(Guid id, CancellationToken cancellationToken = default);
    }
}