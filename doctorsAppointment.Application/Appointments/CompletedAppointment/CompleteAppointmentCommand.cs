using doctorsAppointment.Application.Abstractions.Messaging;

namespace doctorsAppointment.Application.Appointments.CompletedAppointment;

public record CompleteAppointmentCommand(Guid AppointmentId) : ICommand;
