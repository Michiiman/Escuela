using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class User:BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
    public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    public ICollection<UserRole> UserRoles { get; set; }
}