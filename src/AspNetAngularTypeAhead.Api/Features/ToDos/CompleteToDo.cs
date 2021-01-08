using AspNetAngularTypeAhead.Api.Data;
using AspNetAngularTypeAhead.Api.Models;
using FluentValidation;
using MediatR;
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
                RuleFor(request => request.ToDo).NotNull();
                RuleFor(request => request.ToDo).SetValidator(new ToDoValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public ToDoDto ToDo { get; set; }
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

                var toDo = await _context.ToDos.FindAsync(request.ToDo.ToDoId);

                toDo.Complete();

                await _context.SaveChangesAsync(cancellationToken);

			    return new Response() { 
                    ToDo = toDo.ToDto()
                };
            }
        }
    }
}
