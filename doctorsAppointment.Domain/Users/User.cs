using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Shared;

namespace doctorsAppointment.Domain.Users;

public sealed class User : Entity
{
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public Email Email { get; private set; }
}
