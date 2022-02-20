using System;
using System.ComponentModel.DataAnnotations;
using Todo.Domains.Common;

namespace Todo.Domains.Entities
{
    public enum TaskStatus
    {
        Inactive = 1,
        Active = 2,
        Completed = 3
    }
    
    public class Task : BaseEntity
    {
        [MaxLength(200)]
        public string Content { get; set; }
        public TaskStatus Status { get; set; }
        public Guid UserId { get; set; }
    }
    
}