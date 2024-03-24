using doctorsAppointment.Application.Abstractions.Messaging;

namespace doctorsAppointment.Application.Appointments.CancelAppointment;

public sealed record CancelAppointmentCommand(Guid AppointmentId) : ICommand;