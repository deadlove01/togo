namespace Todo.AppServices.Services
{
    public interface IServiceManager
    {
        IUserService UserService { get;}
        ITaskService TaskService { get; }
    }
}