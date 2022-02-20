namespace Todo.AppServices.Services
{
    public interface IAuthService
    {
        string GenerateJWT(string username, string password);
    }
}