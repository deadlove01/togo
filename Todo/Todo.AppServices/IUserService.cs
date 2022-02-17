using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Contracts.User;
using Todo.Domains.Entities;

namespace Todo.AppServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}