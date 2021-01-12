using System;

namespace AspNetAngularTypeAhead.Api.Models
{
    public class ToDo
    {
        public Guid ToDoId { get; private init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime? Completed { get; private set; }
        public DateTime Created { get; init; } = DateTime.UtcNow;
        public DateTime Deleted { get; set; }
        public ToDo(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public void Complete()
        {
            Completed = DateTime.UtcNow;
        }

        public void Remove()
        {
            Deleted = DateTime.UtcNow;
        }
    }
}
