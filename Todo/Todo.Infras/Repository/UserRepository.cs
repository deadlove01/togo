using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Todo.Domains.Entities;
using Todo.Domains.Repository;
using Task = System.Threading.Tasks.Task;

namespace Todo.Infras.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _todoContext;

        public UserRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task AddAsync(User user)
        {
            await _todoContext.Users.AddAsync(user).ConfigureAwait(false);
        }

        public void Remove(User user)
        {
            _todoContext.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var query = GetQuery();
            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = GetQuery();
            return await query
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            var query = GetQuery();
            return await query
                .Where(x => string.Equals(x.Username, username, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        private IQueryable<User> GetQuery()
            => _todoContext.Users.AsQueryable();
    }
}