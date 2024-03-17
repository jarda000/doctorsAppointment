using doctorsAppointment.Domain.Abstractions;

namespace doctorsAppointment.Domain.Appointments.Events;

public sealed record AppointmentCreatedDomainEvent(Guid AppointmentId) : IDomainEvent;
