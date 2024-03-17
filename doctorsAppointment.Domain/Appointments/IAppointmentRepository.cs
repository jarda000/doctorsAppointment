namespace doctorsAppointment.Domain.Appointments;

public interface IAppointmentRepository
{
    void Create(Appointment appointment, CancellationToken cancellationToken = default);
    void Update(Appointment appointment, CancellationToken cancellationToken = default);
    void Delete(Guid id, CancellationToken cancellationToken = default);
    Task<Appointment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Appointment>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}
