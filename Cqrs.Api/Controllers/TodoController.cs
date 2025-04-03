﻿using Cqrs.Application.Queries;
using Cqrs.Application.Queries.GetTodo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateTodos()
        {
            var todoDto = await _mediator.Send(new GetTodoQuery());
            return Ok(todoDto);
        }

    }
}
