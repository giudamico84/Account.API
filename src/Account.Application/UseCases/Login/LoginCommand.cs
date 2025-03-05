using Account.Domain.Common;
using MediatR;

namespace Account.Application.UseCases.Login
{
    public record class LoginCommand(string Email) : IRequest<Result<string>>;
}
