﻿using System;
using System.Collections.Generic;

namespace Account.Infrastructure.Db.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
