using System;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public record ToDoDto(Guid ToDoId, string Title, string Description, DateTime? Completed = null);
}
