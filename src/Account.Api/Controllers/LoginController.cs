using Microsoft.AspNetCore.Mvc;
using MediatR;
using Asp.Versioning;
using System.ComponentModel.DataAnnotations;

namespace Account.Api.Controllers;

[ApiVersion("1.0")]
[ApiController()]
[Route("v{version:apiVersion}/login")]
public class LoginController : ControllerBase
{   
    private readonly IMediator _mediator;
    private readonly ILogger<LoginController> _logger;

    public LoginController(IMediator mediator, ILogger<LoginController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    [Route("login", Order = 1, Name = "GetLogin")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetLogin(string email, CancellationToken cancellationToken)
    {
        //var result = await _mediator.Send("", cancellationToken);

        //if (result.IsSuccess)
        //    return Ok(result.Value);

        //return this.Problem(result.Error);

        return null;
    }
}
