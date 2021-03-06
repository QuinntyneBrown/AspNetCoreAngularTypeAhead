using FluentValidation;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class ToDoValidator : AbstractValidator<ToDoDto>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
        }
    }
}
