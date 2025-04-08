using MediatR;
using Cqrs.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Cqrs.Application.Command.ChangeTodo;
using Cqrs.Application.Command.CreateTodo;
using Cqrs.Application.Queries.GetTodo;

namespace Cqrs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TodoController : Controller
    {

        private readonly ISender _mediator;

        public TodoController(ISender mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTodos()
        {
            var todoDto = await _mediator.Send(new GetTodoQuery());
            return Ok(todoDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTodos([FromBody] CreateTodoRequest todoRequest)
        {
                 var createTodoCommand = new CreateTodoCommand(Guid.NewGuid(), todoRequest.TodoName);
            await _mediator.Send(createTodoCommand);

            return CreatedAtAction("CreateTodos", "TodoController");
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeTodos(ChangeTodoRequest changeRequest)
        {
            var updateTodoCommand =
                new ChangeTodoCommand(changeRequest.Id, changeRequest.TodoName, changeRequest.IsCompleted);

            await _mediator.Send(updateTodoCommand);
            return CreatedAtAction("ChangeTodos", "TodoController");
        }
    }
}
