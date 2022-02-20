using AutoMapper;
using Todo.Contracts.Task;
using Todo.Domains.Entities;

namespace Todo.AppServices.Mapper
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<Task, TaskResponse>();
            CreateMap<CreateTaskRequest, Task>();
        }
    }
}