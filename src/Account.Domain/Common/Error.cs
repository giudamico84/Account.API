using System.Text;

namespace Account.Domain.Common
{
    public readonly struct Error
    {
        public Error(string code, string? description = null)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }

        public string? Description { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Code: {Code}");            
            if (Description != null)
                sb.Append($", Description: {Description}");
            return sb.ToString();
        }
    }
}
