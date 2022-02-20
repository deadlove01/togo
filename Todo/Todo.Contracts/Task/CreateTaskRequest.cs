using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Contracts.Task
{
    public class CreateTaskRequest
    {
        [Required(ErrorMessage = "Todo content is required")]
        [StringLength(200, ErrorMessage = "Todo content can't be longer than 200 characters")]
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}