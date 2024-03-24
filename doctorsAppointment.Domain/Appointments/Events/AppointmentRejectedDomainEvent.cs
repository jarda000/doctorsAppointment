using doctorsAppointment.Domain.Abstractions;

namespace doctorsAppointment.Domain.Appointments.Events;

public sealed record AppointmentRejectedDomainEvent(Guid AppointmentId) : IDomainEvent;
