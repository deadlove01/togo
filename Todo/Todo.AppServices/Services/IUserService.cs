﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Contracts.User;
using Todo.Domains.Entities;

namespace Todo.AppServices.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken);
        Task<UserResponse> GetUserByUsernameAsync(string username, string password, CancellationToken cancellationToken = default);
        Task<UserResponse> GetUserbyIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}