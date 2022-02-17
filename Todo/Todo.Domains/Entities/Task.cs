using System;
using System.ComponentModel.DataAnnotations;
using Todo.Domains.Common;

namespace Todo.Domains.Entities
{
    public enum TaskStatus
    {
        Active = 1,
        Completed = 2
    }
    
    public class Task : BaseEntity
    {
        [MaxLength(200)]
        public string Content { get; set; }
        public TaskStatus Status { get; set; }
        public Guid UserId { get; set; }
    }
    
}