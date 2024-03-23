﻿using doctorsAppointment.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Appointments.ConfirmAppointment;

public record ConfirmAppointmentCommand(Guid AppointmentId) : ICommand;
