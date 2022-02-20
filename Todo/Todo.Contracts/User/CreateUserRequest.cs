using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Todo.Contracts.User
{
    public class CreateUserRequest
    {
        [MaxLength(100)] public string FirstName { get; set; }
        [MaxLength(100)] public string LastName { get; set; }
        [Required][MaxLength(100)] public string Username { get; set; }
        [MaxLength(200)] public string Password { get; set; }
        // [Required] public Membership Membership { get; set; }
    }
}