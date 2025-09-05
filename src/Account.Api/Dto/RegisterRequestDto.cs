namespace Account.Api.Dto
{
    public record class RegisterRequestDto
    {
        public string Email { get; init; }

        public string Password { get; init; }

        public RegisterRequestDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
