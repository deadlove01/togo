using System;

namespace Todo.AppServices.Services
{
    public interface IAuthService
    {
        string GenerateJWT(Guid userId);
    }
}