using AspNetAngularTypeAhead.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class GetToDos
    {
        public record Request : IRequest<Response>;

        public record Response(List<ToDoDto> ToDos);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetAngularTypeAheadDbContext _context;

            public Handler(IAspNetAngularTypeAheadDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new (await _context.ToDos.Select(x => x.ToDto()).ToListAsync());
        }
    }
}
