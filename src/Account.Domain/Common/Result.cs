namespace Account.Domain.Common
{
    public readonly struct Result
    {
        private Result(bool success, Error? error)
        {
            IsSuccess = success;
            Error = error;
        }

        public bool IsSuccess { get; }

        public Error? Error { get; }

        public static readonly Result Success = new(true, null);

        public static Result Fail(Error error) => new(false, error);

        public static Result Fail(string errorCode, string? description = null)
            => Fail(new Error(errorCode, description));

        public static implicit operator Result(Error error) => new(false, error);
    }
}
