using System;
using System.Collections.Generic;

namespace Account.Infrastructure.Db.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
