using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domains.Entities;
using Todo.Domains.Repository;

namespace Todo.Infras.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _todoContext;

        public UserRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _todoContext.Users.ToListAsync(cancellationToken);
        }

        public Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}