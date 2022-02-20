using System;

namespace Todo.Domains.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid id)
            : base($"User with id {id} was not found.")
        {
            
        }
    }
}