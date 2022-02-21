using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Todo.Contracts.Task;
using Todo.Domains.Common;
using Todo.Domains.Exceptions;
using Todo.Domains.Repository;
using TaskStatus = Todo.Domains.Entities.TaskStatus;
using TodoTask = Todo.Domains.Entities.Task;

namespace Todo.AppServices.Services.Concrete
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly MembershipConfigs _membershipConfigs;

        public TaskService(IRepositoryManager repositoryManager, IMapper mapper,
            MembershipConfigs membershipConfigs)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _membershipConfigs = membershipConfigs;
        }

        public async Task<IEnumerable<TaskResponse>> GetTasksAsync(CancellationToken cancellationToken = default)
        {
            var tasks = await _repositoryManager.TaskRepository.GetTasksAsync(cancellationToken);
            var result =  _mapper.Map<List<TaskResponse>>(tasks);
            return result;
        }

        public async Task<IEnumerable<TaskResponse>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var tasks = await _repositoryManager.TaskRepository.GetTasksByUserIdAsync(userId, cancellationToken);
            var result =  _mapper.Map<List<TaskResponse>>(tasks);
            return result;
        }

        public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest createTaskRequest, CancellationToken cancellationToken = default)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(createTaskRequest.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(createTaskRequest.UserId.ToString());
            }

            var limitedTasksInDay = _membershipConfigs
                .FirstOrDefault(x => x.Title == user.Membership.ToString());
            
            var numberOfTasksInDay = await _repositoryManager.TaskRepository.CountTaskByDateAsync(user.Id,
                DateTimeOffset.Now, cancellationToken);
            if (limitedTasksInDay != null && numberOfTasksInDay >= limitedTasksInDay.MaxTasksPerDay)
            {
                throw new BadRequestException($"Your account can only create {limitedTasksInDay.MaxTasksPerDay} per day.");
            }
            
            var todoTask = _mapper.Map<TodoTask>(createTaskRequest);
            todoTask.Id = Guid.NewGuid();
            todoTask.CreatedDate = DateTimeOffset.UtcNow;
            todoTask.Status = TaskStatus.Inactive;
            await _repositoryManager.TaskRepository.AddAsync(todoTask);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            var todoTaskResponse = _mapper.Map<TaskResponse>(todoTask);
            return todoTaskResponse;
        }

        public async Task<TaskResponse> UpdateTaskAsync(Guid id, UpdateTaskRequest updateTaskRequest, CancellationToken cancellationToken = default)
        {
            var todoTask =
                await _repositoryManager.TaskRepository.GetTaskByIdAsync(id, cancellationToken);
            if (todoTask == null) return null;

            todoTask.Content = updateTaskRequest.Content;
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            var todoTaskResponse = _mapper.Map<TaskResponse>(todoTask);
            return todoTaskResponse;
        }

        public async Task<TaskResponse> RemoveTaskAysnc(Guid id, CancellationToken cancellationToken = default)
        {
            var todoTask =
                await _repositoryManager.TaskRepository.GetTaskByIdAsync(id, cancellationToken);
            if (todoTask == null) return null;
            _repositoryManager.TaskRepository.Remove(todoTask);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            var todoTaskResponse = _mapper.Map<TaskResponse>(todoTask);
            return todoTaskResponse;
        }
    }
}