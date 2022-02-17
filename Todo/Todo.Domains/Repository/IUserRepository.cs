using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Domains.Entities;

namespace Todo.Domains.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Remove(User user);
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    }
}