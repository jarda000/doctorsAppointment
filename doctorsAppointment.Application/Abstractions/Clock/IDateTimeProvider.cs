using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Abstractions.Clock;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
