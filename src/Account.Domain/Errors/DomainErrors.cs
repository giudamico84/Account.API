using Account.Domain.Common;

namespace Account.Domain.Errors
{
    public class DomainErrors
    {
        protected DomainErrors() { }

        public static readonly Error UserNotFound = Error.NotFound("UserRepository.UserNotFound", "User not found");       
    }
}
