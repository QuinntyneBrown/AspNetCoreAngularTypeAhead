using AspNetAngularTypeAhead.Api.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class RemoveToDo
    {
        public record Request (Guid ToDoId): IRequest<Unit>;

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IAspNetAngularTypeAheadDbContext _context;

            public Handler(IAspNetAngularTypeAheadDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {
                
                _context.ToDos.Remove(await _context.ToDos.FindAsync(request.ToDoId));
                
                await _context.SaveChangesAsync(cancellationToken);			    
                
                return new ();
            }
        }
    }
}
