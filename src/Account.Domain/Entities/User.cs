﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Entities
{
    public class User
    {
        public required int Id { get; set; }
        public required string Email { get; set; }
    }
}
