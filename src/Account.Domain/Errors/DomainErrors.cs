using Account.Domain.Common;

namespace Account.Domain.Errors
{
    public class DomainErrors
    {
        protected DomainErrors() { }

        public const string DOMAIN = "ACCOUNT";

        public static readonly Error AnalyticsServerError = new("E001", DOMAIN, "Analytics Server Error");       

    }
}
