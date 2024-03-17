using doctorsAppointment.Application.Abstractions.Email;
using doctorsAppointment.Domain.Appointments;
using doctorsAppointment.Domain.Appointments.Events;
using doctorsAppointment.Domain.Patients;
using MediatR;

namespace doctorsAppointment.Application.Appointments.BookAppointment;

public sealed class AppointmentBookedEventHandler : INotificationHandler<AppointmentBookedDomainEvent>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IEmailService _emailService;
    private readonly IPatientRepository _patientRepository;
    public async Task Handle(AppointmentBookedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
