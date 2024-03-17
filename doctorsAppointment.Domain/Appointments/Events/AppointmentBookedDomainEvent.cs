using doctorsAppointment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Appointments.Events;

public sealed record AppointmentBookedDomainEvent(Guid AppointmentId) : IDomainEvent;
