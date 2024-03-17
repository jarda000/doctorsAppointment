using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Appointments;

public sealed class Appointment : Entity
{
    public DateTime CreatedOnUtc { get; private set; }
    public DateRange Duration { get; private set; }
    public Patient Patient { get; private set; }
}
