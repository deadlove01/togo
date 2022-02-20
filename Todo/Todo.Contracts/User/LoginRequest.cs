using System.ComponentModel.DataAnnotations;

namespace Todo.Contracts.User
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}