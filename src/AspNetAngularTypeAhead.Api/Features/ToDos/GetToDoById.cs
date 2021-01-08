using AspNetAngularTypeAhead.Api.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class GetToDoById
    {
        public class Request : IRequest<Response> {  
            public Guid ToDoId { get; set; }        
        }

        public class Response
        {
            public ToDoDto ToDo { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetAngularTypeAheadDbContext _context;

            public Handler(IAspNetAngularTypeAheadDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    ToDo = (await _context.ToDos.FindAsync(request.ToDoId)).ToDto()
                };
            }
        }
    }
}
