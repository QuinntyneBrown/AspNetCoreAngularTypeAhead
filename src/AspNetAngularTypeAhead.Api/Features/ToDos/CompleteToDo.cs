using AspNetAngularTypeAhead.Api.Data;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class CompleteToDo
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ToDoId).NotNull();
                RuleFor(request => request.ToDoId).NotEqual(new Guid());
            }
        }

        public record Request(Guid ToDoId) : IRequest<Response>;

        public record Response(ToDoDto ToDo);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetAngularTypeAheadDbContext _context;

            public Handler(IAspNetAngularTypeAheadDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var toDo = await _context.ToDos.FindAsync(request.ToDoId);

                toDo.Complete();

                await _context.SaveChangesAsync(cancellationToken);

                return new(toDo.ToDto());
            }
        }
    }
}
