using doctorsAppointment.Domain.Abstractions;

namespace doctorsAppointment.Domain.Appointments.Events;

public sealed record AppointmentConfirmedDomainEvent(Guid AppointmentId) : IDomainEvent;
