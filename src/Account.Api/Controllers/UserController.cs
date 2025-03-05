using Microsoft.AspNetCore.Mvc;
using MediatR;
using Asp.Versioning;
using Account.Api.Extensions;
using Account.Application.UseCases.Login;

namespace Account.Api.Controllers;

[ApiVersion("1.0")]
[ApiController()]
[Route("v{version:apiVersion}/user")]
public class UserController : ControllerBase
{   
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [Route("login", Order = 1, Name = "LoginUser")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var loginCommand = new LoginCommand(loginRequest.Email);
        
        var result = await _mediator.Send(loginCommand, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return this.Problem(result.Error);
    }
}
