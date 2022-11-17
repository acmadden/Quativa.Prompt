using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quativa.Ports.Application.Exceptions;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Application.UseCases.CreateTodoList;
using Quativa.Ports.Application.UseCases.FetchSingleTodoList;
using Quativa.Ports.Application.UseCases.ListTodoLists;

namespace Quativa.Adapters.Web.Controllers;

[ApiController]
public sealed class TodoListController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("lists")]
    public async Task<ActionResult<TodoListReadModel>> CreateAsync([FromBody] CreateTodoListCommand command)
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

    [HttpGet("lists")]
    public async Task<ActionResult<List<TodoListReadModel>>> ListAsync()
    {
        return Ok(await _mediator.Send(new ListTodoListsQuery()));
    }

    [HttpGet("lists/{listId}")]
    public async Task<ActionResult<TodoListReadModel>> FetchSingleAsync([FromRoute] Guid listId)
    {
        try
        {
            return Ok(await _mediator.Send(new FetchSingleTodoListQuery(listId)));
        }
        catch (EntityNotFoundException e)
        {
            return Problem(e.Message, statusCode: (int)HttpStatusCode.NotFound);
        }
    }
}