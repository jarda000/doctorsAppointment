using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Application.Appointments.GetAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Appointments.ListAppointments;

internal sealed record ListAppointmentsByPatientQuery(Guid PatientId) : IQuery<IReadOnlyList<AppointmentResponse>>;