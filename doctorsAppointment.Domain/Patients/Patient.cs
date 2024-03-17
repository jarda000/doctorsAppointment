using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Shared;

namespace doctorsAppointment.Domain.Patients;

public sealed class Patient : Entity
{
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    private Patient()
    {
    }
    public Patient(Guid id, Name firstName, Name lastName, Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
