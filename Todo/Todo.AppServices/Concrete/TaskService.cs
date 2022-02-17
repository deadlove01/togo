using Todo.Domains.Repository;

namespace Todo.AppServices.Concrete
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TaskService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}