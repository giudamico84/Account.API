using System.Text;

namespace Account.Domain.Common
{
    public readonly struct Error
    {
        public Error(string code, string? domain = null, string? description = null)
        {
            Code = code;
            Domain = domain;
            Description = description;
        }

        public string Code { get; }

        public string? Domain { get; }

        public string? Description { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Code: {Code}");
            if (Domain != null)
                sb.Append($", Domain: {Domain}");
            if (Description != null)
                sb.Append($", Description: {Description}");
            return sb.ToString();
        }
    }
}
