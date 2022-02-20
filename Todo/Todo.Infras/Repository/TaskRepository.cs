using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domains.Repository;
using TodoTask = Todo.Domains.Entities.Task;

namespace Todo.Infras.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _context;

        public TaskRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoTask task)
        {
            await _context.Tasks.AddAsync(task).ConfigureAwait(false);
        }

        public void Remove(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<IEnumerable<TodoTask>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var query = GetQuery();
            return await query.Where(x => x.UserId == userId).
                ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TodoTask>> GetTasksAsync(CancellationToken cancellationToken = default)
        {
            var query = GetQuery();
            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TodoTask> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = GetQuery();
            return await query.Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        private IQueryable<TodoTask> GetQuery()
        {
            return _context.Tasks.AsQueryable();
        }
    }
}