using doctorsAppointment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Patients;

internal interface IPatientRepository
{
    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Patient> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
