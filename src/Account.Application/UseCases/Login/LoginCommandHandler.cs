using Account.Domain.Common;
using Account.Domain.Errors;
using Account.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.UseCases.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(IUserRepository userRepository, ILogger<LoginCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }       

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (!user.IsSuccess)
            {
                return DomainErrors.UserNotFound;
            }

            //generate jwt

            //return jwt

            return null;
        }
    }
}
