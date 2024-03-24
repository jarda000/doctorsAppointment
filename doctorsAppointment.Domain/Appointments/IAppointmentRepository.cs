namespace doctorsAppointment.Domain.Appointments;

public interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
