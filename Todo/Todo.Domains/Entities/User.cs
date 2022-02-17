using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Todo.Domains.Common;

namespace Todo.Domains.Entities
{
    public enum Membership
    {
        Basic = 1,
        Standard = 2,
        Premium = 3
    }
    
    public class User : BaseEntity
    {
        [MaxLength(100)] public string FirstName { get; set; }
        [MaxLength(100)] public string LastName { get; set; }
        [MaxLength(100)] public string Username { get; set; }
        [MaxLength(200)] public string Password { get; set; }
        public Membership Membership { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}