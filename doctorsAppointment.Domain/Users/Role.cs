using doctorsAppointment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Users;

public sealed class Role(int id, Name name)
{
    public int Id { get; init; } = id;
    public Name Name { get; init; } = name;
    public static readonly Role Admin = new(1, new Name("Admin"));
    public static readonly Role User = new(2, new Name("User"));
    public ICollection<User> Users { get; private set; } = new List<User>();
}
