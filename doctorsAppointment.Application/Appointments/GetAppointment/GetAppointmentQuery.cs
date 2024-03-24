using doctorsAppointment.Application.Abstractions.Messaging;

namespace doctorsAppointment.Application.Appointments.GetAppointment;

internal sealed record GetAppointmentQuery(Guid AppointmentId) : IQuery<AppointmentResponse>;
