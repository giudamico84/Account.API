﻿using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
