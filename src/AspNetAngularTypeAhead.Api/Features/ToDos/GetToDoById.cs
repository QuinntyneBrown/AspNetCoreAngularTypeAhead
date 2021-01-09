using AspNetAngularTypeAhead.Api.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class GetToDoById
    {
        public record Request(Guid ToDoId) : IRequest<Response>;

        public record Response(ToDoDto ToDo);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetAngularTypeAheadDbContext _context;

            public Handler(IAspNetAngularTypeAheadDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new((await _context.ToDos.FindAsync(request.ToDoId)).ToDto());
        }
    }
}
