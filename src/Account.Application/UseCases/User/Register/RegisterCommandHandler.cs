using Account.Domain.Common;
using Account.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.UseCases.User.Register
{
    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(IUserRepository userRepository, ILogger<RegisterCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.CreateUserAsync(request.Email, PasswordHashing.Hash(request.Password));
            }
            catch (Exception)
            {
                return Domain.Errors.DomainErrors.UserNotCreated;
            }
        }
    }
}
