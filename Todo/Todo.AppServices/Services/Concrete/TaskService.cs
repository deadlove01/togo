using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Todo.Contracts.Task;
using Todo.Domains.Exceptions;
using Todo.Domains.Repository;
using TodoTask = Todo.Domains.Entities.Task;

namespace Todo.AppServices.Services.Concrete
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TaskService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
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
            
            var todoTask = _mapper.Map<TodoTask>(createTaskRequest);
            todoTask.Id = Guid.NewGuid();
            todoTask.CreatedDate = DateTimeOffset.UtcNow;
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