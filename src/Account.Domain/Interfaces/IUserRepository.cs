using Account.Domain.Entities;

namespace Account.Domain.Interfaces
{
    public interface IUserRepository
    {
        ValueTask<User> GetUserByEmailAsync(string email);
        ValueTask<int> CreateUserAsync(string email, string passwordHash);
    }
}
