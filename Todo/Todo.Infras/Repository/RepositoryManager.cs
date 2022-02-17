using System;
using Todo.Domains.Repository;

namespace Todo.Infras.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOrWork;
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<ITaskRepository> _lazyTaskRepository;
        public RepositoryManager(TodoContext context)
        {
            _lazyUnitOrWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _lazyTaskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(context));
        }

        public IUserRepository UserRepository => _lazyUserRepository.Value;
        public ITaskRepository TaskRepository => _lazyTaskRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOrWork.Value;
    }
}