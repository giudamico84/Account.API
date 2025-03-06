using Account.Domain.Common;
using Account.Domain.Entities;
using Account.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public async ValueTask<Result<User>> GetUserByEmailAsync(string email)
        {
            return await Task.FromResult(new User
            {
                Id = Guid.NewGuid(),
                Email = email
            });
        }
    }
}
