using System;
using System.Collections.Generic;

namespace Account.Infrastructure.Db.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime AssignedAt { get; set; }

    public virtual Role Role { get; set; }

    public virtual User User { get; set; }
}
