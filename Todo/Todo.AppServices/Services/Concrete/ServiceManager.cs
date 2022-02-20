using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Todo.Domains.Repository;

namespace Todo.AppServices.Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<ITaskService> _lazyTaskService;
        private readonly Lazy<IAuthService> _lazyAuthService;
        
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration)
        {
            _lazyTaskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(configuration));
        }

        public IUserService UserService => _lazyUserService.Value;
        public ITaskService TaskService => _lazyTaskService.Value;
        
        public IAuthService AuthService => _lazyAuthService.Value;
    }
}