using doctorsAppointment.Domain.Shared;

namespace doctorsAppointment.Domain.Patients;

public interface IPatientRepository
{
    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Patient> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
