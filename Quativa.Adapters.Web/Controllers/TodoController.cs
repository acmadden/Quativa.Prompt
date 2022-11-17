using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quativa.Ports.Application.Exceptions;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Application.UseCases.CreateTodo;
using Quativa.Ports.Application.UseCases.DeleteTodo;
using Quativa.Ports.Application.UseCases.ListTodos;
using Quativa.Ports.Application.UseCases.SetTodo;

namespace Quativa.Adapters.Web.Controllers;

[ApiController]
public sealed class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("todos")]
    public async Task<ActionResult<TodoReadModel>> CreateAsync([FromBody] CreateTodoCommand command)
    {
        try
        {
            return Ok(await _mediator.Send(command));
        }
        catch (ArgumentException e)
        {
            return Problem(e.Message, statusCode: (int)HttpStatusCode.BadRequest);
        }
    }

    [HttpGet("todos")]
    public async Task<ActionResult<List<TodoReadModel>>> ListAsync()
    {
        return Ok(await _mediator.Send(new ListTodosQuery()));
    }

    [HttpPut("todos/{todoId}")]
    public async Task<ActionResult<TodoReadModel>> SetAsync([FromRoute] Guid todoId, [FromBody] SetTodoCommand command)
    {
        try
        {
            command.TodoId = todoId;
            return Ok(await _mediator.Send(command));
        }
        catch (ArgumentException e)
        {
            return Problem(e.Message, statusCode: (int)HttpStatusCode.BadRequest);
        }
        catch (EntityNotFoundException e)
        {
            return Problem(e.Message, statusCode: (int)HttpStatusCode.NotFound);
        }
    }

    [HttpDelete("todos/{todoId}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid todoId)
    {
        try
        {
            await _mediator.Send(new DeleteTodoCommand(todoId));
            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return Problem(e.Message, statusCode: (int)HttpStatusCode.NotFound);
        }
    }
}