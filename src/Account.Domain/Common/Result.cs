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

        public static Result Fail(string errorCode, string description, ErrorType type)
            => Fail(new Error(errorCode, description, type));

        public static implicit operator Result(Error error) => new(false, error);
    }

    public readonly struct Result<T>
    {
        private Result(bool success, T? value, Error? error)
        {
            IsSuccess = success;
            Error = error;
            Value = value;
        }

        public bool IsSuccess { get; }

        public Error? Error { get; }

        public static Result<T> Success(T value) => new(true, value, null);

        public static Result<T> Fail(Error error) => new(false, default, error);

        public T? Value { get; }

        public static implicit operator Result<T>(T value) => new(true, value, default);

        public static implicit operator T?(Result<T> result)
        {
            if (!result.IsSuccess)
                throw new InvalidCastException("The result was not successful");

            return result.Value;
        }

        public static implicit operator Result<T>(Error error) => new(false, default, error);
    }
}
