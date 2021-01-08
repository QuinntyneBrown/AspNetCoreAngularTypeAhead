using AspNetAngularTypeAhead.Api.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class SearchToDo
    {
        public class Request : IRequest<Response> {
            public string Query { get; set; }
        }

        public class Response
        {
            public List<ToDoDto> ToDos { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetAngularTypeAheadDbContext _context;

            public Handler(IAspNetAngularTypeAheadDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                return new();
            }
        }
    }
}
