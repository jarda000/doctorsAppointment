using doctorsAppointment.Domain.Abstractions;

namespace doctorsAppointment.Domain.Appointments.Events;

public sealed record AppointmentCanceledDomainEvent(Guid AppointmentId) : IDomainEvent;
