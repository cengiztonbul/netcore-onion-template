using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionTemplate.Application.Features.Commands;
using OnionTemplate.Application.Features.Queries;

namespace OnionTemplate.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleEntityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ExampleEntityController> _logger;

	public ExampleEntityController(IMediator mediator, ILogger<ExampleEntityController> logger)
	{
		_mediator = mediator;
		_logger = logger;
	}

	[HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("******** Information Get");
        _logger.LogDebug("******** Debug Get");
        _logger.LogCritical("******** Critical Get");
        _logger.LogError("******** Error Get");
        var query = new GetAllExampleEntitiesQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]Guid id)
    {
        var query = new GetSingleExampleEntityQuery(id);
        return Ok(await _mediator.Send(query));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateExampleEntityCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("/Delete")]
    public async Task<IActionResult> Delete(DeleteExampleEntityCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
