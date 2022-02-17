namespace Todo.AppServices
{
    public interface IServiceManager
    {
        IUserService UserService { get;}
        ITaskService TaskService { get; }
    }
}