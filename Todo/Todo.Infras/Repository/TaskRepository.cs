using System;
using System.Collections.Generic;
using System.Threading;
using Todo.Domains.Entities;
using Todo.Domains.Repository;

namespace Todo.Infras.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _context;

        public TaskRepository(TodoContext context)
        {
            _context = context;
        }

        public void Add(Task task)
        {
            throw new NotImplementedException();
        }

        public void Remove(Task task)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}