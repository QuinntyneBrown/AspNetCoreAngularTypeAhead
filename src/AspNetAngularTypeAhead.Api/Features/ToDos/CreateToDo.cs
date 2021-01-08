using AspNetAngularTypeAhead.Api.Data;
using AspNetAngularTypeAhead.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Features.ToDos
{
    public class CreateToDo
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

                var toDo = new ToDo(request.ToDo.Description);

                await _context.ToDos.AddAsync(toDo);

                await _context.SaveChangesAsync(cancellationToken);

			    return new () { 
                    ToDo = toDo.ToDto()
                };
            }
        }
    }
}
