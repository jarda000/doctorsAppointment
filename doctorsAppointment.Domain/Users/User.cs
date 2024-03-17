﻿using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Users;

public sealed class User : Entity
{
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public Email Email { get; private set; }
}
