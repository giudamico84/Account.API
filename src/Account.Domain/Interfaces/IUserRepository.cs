﻿using Account.Domain.Common;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces
{
    public interface IUserRepository
    {
        ValueTask<Result<User>> GetUserByEmailAsync(string email);
    }
}
