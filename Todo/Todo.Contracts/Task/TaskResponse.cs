using System;
using System.Threading.Tasks;

namespace Todo.Contracts.Task
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public Guid UserId { get; set; }
    }
}