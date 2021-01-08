using AspNetAngularTypeAhead.Api.Features.ToDos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Controllers
{
    [ApiController]
    [Route("api/toDos")]
    public class ToDosController
    {
        private readonly IMediator _mediator;

        public ToDosController(IMediator mediator) => _mediator = mediator;

        [HttpPost(Name = "CreateToDoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateToDo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateToDo.Response>> Create([FromBody]CreateToDo.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "CompleteToDoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CompleteToDo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompleteToDo.Response>> Complete([FromBody]CompleteToDo.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{toDoId}", Name = "RemoveToDoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute]RemoveToDo.Request request)
            => await _mediator.Send(request);

        [HttpGet("{toDoId}", Name = "GetToDoByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetToDoById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetToDoById.Response>> GetById([FromRoute]GetToDoById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.ToDo == null)
            {
                return new NotFoundObjectResult(request.ToDoId);
            }

            return response;
        }

        [HttpGet(Name = "GetToDosRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetToDos.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetToDos.Response>> Get()
            => await _mediator.Send(new GetToDos.Request());           
    }
}
