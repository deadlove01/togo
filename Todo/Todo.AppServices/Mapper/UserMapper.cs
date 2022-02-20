using AutoMapper;
using Todo.Contracts.User;
using Todo.Domains.Entities;

namespace Todo.AppServices.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserResponse>();
            CreateMap<CreateUserRequest, User>();
        }
    }
}