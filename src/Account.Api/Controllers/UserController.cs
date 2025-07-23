using Microsoft.AspNetCore.Mvc;
using MediatR;
using Asp.Versioning;
using Account.Api.Extensions;
using Account.Application.UseCases.Login;
using Account.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Account.Application.UseCases.User.GetUser;
using Microsoft.AspNetCore.Authorization;

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
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var loginCommand = new LoginCommand(loginRequest.Email);
        
        var result = await _mediator.Send(loginCommand, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return this.Problem(result.Error);
    }

    [Authorize]
    [HttpGet]
    [Route("{email}", Order = 2, Name = "GetUserByEmail")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserByEmailAsync([Required] string email, CancellationToken cancellationToken)
    {
        var getUserQuery = new GetUserQuery(email);

        var result = await _mediator.Send(getUserQuery, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return this.Problem(result.Error);
    }
}
