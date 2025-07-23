using Account.Application.UseCases.Login;
using Account.Domain.Common;
using Account.Domain.Errors;
using Account.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.UseCases.User.GetUser
{
    public sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<Domain.Entities.User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginCommandHandler> _logger;

        public GetUserQueryHandler(IUserRepository userRepository, ILogger<LoginCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<Account.Domain.Entities.User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return DomainErrors.UserNotFound;
            }

            return user;
        }
    }
}