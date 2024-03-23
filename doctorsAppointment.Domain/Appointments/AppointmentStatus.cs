using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Appointments;

public enum AppointmentStatus
{
    Pending = 0,
    Scheduled = 1,
    Rejected = 2,
    Cancelled = 3,
    Completed = 4
}
public enum AppointmentCreator
{
    Patient = 0,
    Doctor = 1
}
