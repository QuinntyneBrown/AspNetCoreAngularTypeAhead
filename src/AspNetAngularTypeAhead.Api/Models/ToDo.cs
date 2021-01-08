using System;

namespace AspNetAngularTypeAhead.Api.Models
{
    public class ToDo
    {
        public Guid ToDoId { get; private init; }
        public string Description { get; init; }
        public DateTime? Completed { get; private set; }
        public DateTime Created { get; init; } = DateTime.UtcNow;

        public ToDo(string description)
        {
            Description = description;
        }
        public void Complete()
        {
            Completed = DateTime.UtcNow;
        }
    }
}
