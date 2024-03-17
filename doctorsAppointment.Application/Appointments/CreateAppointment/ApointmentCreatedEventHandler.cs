using doctorsAppointment.Application.Abstractions.Email;
using doctorsAppointment.Domain.Appointments;
using doctorsAppointment.Domain.Appointments.Events;
using doctorsAppointment.Domain.Patients;
using MediatR;

namespace doctorsAppointment.Application.Appointments.CreateAppointment;

public sealed class ApointmentCreatedEventHandler(IAppointmentRepository appointmentRepository, IEmailService emailService, IPatientRepository patientRepository) : INotificationHandler<AppointmentCreatedDomainEvent>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly IPatientRepository _patientRepository = patientRepository;
    private const string SUBJECT = "Appointment Created";
    private const string MESSAGE = "You have 10 minutes to confirm this appointment";

    public async Task Handle(AppointmentCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(notification.AppointmentId, cancellationToken);
        if (appointment is null)
        {
            return;
        }
        var patient = await _patientRepository.GetByEmailAsync(appointment.Patient.Email, cancellationToken);
        if (patient is null)
        {
            return;
        }
        await _emailService.SendAsync(patient.Email, SUBJECT, MESSAGE);
    }
}
