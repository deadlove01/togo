using System.Threading;
using System.Threading.Tasks;

namespace Todo.Domains.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}