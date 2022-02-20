using System;

namespace Todo.Domains.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string data)
            : base($"User with data {data} was not found.")
        {
            
        }
    }
}