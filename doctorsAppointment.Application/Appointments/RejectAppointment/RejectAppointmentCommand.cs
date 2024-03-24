using doctorsAppointment.Application.Abstractions.Messaging;

namespace doctorsAppointment.Application.Appointments.RejectAppointment;

public sealed record RejectAppointmentCommand(Guid AppointmentId) : ICommand;
