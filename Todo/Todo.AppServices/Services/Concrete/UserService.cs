using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Todo.Contracts.User;
using Todo.Domains.Entities;
using Todo.Domains.Exceptions;
using Todo.Domains.Repository;

namespace Todo.AppServices.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _repositoryManager.UserRepository.GetAllUsersAsync(cancellationToken);
            var result =  _mapper.Map<List<UserResponse>>(users);
            return result;
        }

        public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(createUserRequest);
            user.Id = Guid.NewGuid();
            user.CreatedDate = DateTimeOffset.UtcNow;
            await _repositoryManager.UserRepository.AddAsync(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            var userResponse = _mapper.Map<UserResponse>(user);
            return userResponse;
        }

        public async Task<UserResponse> GetUserByUsernameAsync(string username, string password,
            CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetUserByUsernameAsync(username, cancellationToken);
            if (user == null)
            {
                throw new UserNotFoundException(username);
            }

            if (!string.Equals(user.Password, password))
            {
                return null;
            }
            
            var userResponse = _mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}