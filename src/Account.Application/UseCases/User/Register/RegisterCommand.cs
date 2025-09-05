using Account.Domain.Common;
using MediatR;

namespace Account.Application.UseCases.User.Register
{
    public record class RegisterCommand(string Email, string Password) : IRequest<Result<int>>;
}
