using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Task = Todo.Domains.Entities.Task;

namespace Todo.Domains.Repository
{
    public interface ITaskRepository
    {
        void Add(Task task);
        void Remove(Task task);
        Task<IEnumerable<Task>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}