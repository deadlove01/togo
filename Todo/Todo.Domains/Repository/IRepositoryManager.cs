using System.Threading;
using System.Threading.Tasks;

namespace Todo.Domains.Repository
{
    public interface IRepositoryManager
    {
        public IUserRepository UserRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public IUnitOfWork UnitOfWork { get; }
    }
}