using System;
using AutoMapper;
using Todo.Domains.Repository;

namespace Todo.AppServices.Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<ITaskService> _lazyTaskService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyTaskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
        }

        public IUserService UserService => _lazyUserService.Value;
        public ITaskService TaskService => _lazyTaskService.Value;
    }
}