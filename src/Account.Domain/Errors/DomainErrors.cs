using Account.Domain.Common;

namespace Account.Domain.Errors
{
    public class DomainErrors
    {
        protected DomainErrors() { }

        const string DOMAIN = "Account.Api";

        public static readonly Error UserNotFound = new("UserRepository.UserNotFound", DOMAIN, "User not found");       

    }
}
