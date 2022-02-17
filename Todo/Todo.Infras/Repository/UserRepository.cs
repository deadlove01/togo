using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

        public Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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