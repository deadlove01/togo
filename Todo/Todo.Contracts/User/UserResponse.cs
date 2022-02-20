using System;

namespace Todo.Contracts.User
{
    public class UserResponse
    {
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
    }
}