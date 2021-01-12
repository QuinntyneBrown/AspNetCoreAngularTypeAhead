using AspNetAngularTypeAhead.Api.Data;
using AspNetAngularTypeAhead.Api.Models;
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

                var toDo = await _context.FindAsync<ToDo>(request.ToDoId);

                toDo.Remove();
                
                await _context.SaveChangesAsync(cancellationToken);			    
                
                return new ();
            }
        }
    }
}
