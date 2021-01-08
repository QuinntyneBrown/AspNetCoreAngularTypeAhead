using AspNetAngularTypeAhead.Api.Features.ToDos;
using AspNetAngularTypeAhead.Api.Models;

namespace AspNetAngularTypeAhead.Api.Features
{
    public static class ToDoExtensions
    {
        public static ToDoDto ToDto(this ToDo toDo)
            => new ToDoDto(toDo.ToDoId, toDo.Title, toDo.Description, toDo.Completed);
    }
}
