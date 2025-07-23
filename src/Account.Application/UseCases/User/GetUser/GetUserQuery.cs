using Account.Domain.Common;
using MediatR;

namespace Account.Application.UseCases.User.GetUser
{
    public record class GetUserQuery(string Email) : IRequest<Result<Domain.Entities.User>>;
}