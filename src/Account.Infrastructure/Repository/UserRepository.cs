using Account.Domain.Common;
using Account.Domain.Entities;
using Account.Domain.Interfaces;
using Account.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async ValueTask<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(t => t.Email == email);

            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                Email = user.Email
            };
        }
    }
}
