using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Shared.Email recipient, string subject, string body);
}
