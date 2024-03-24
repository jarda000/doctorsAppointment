using doctorsAppointment.Application.Abstractions.Messaging;

namespace doctorsAppointment.Application.Appointments.ConfirmAppointment;

public record ConfirmAppointmentCommand(Guid AppointmentId) : ICommand;
