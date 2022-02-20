using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoTask = Todo.Domains.Entities.Task;

namespace Todo.Domains.Repository
{
    public interface ITaskRepository
    {
        Task AddAsync(TodoTask task);
        void Remove(TodoTask task);
        Task<IEnumerable<TodoTask>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        
        Task<IEnumerable<TodoTask>> GetTasksAsync(CancellationToken cancellationToken = default);
        Task<TodoTask> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}