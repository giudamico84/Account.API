using Account.Domain.Entities;
using Account.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public string Generate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
