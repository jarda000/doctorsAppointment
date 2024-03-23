using doctorsAppointment.Application.Abstractions.Clock;
using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Appointments.CancelAppointment;

internal sealed class CancelAppointmentCommandHandler : ICommandHandler<CancelAppointmentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    public async Task<Result> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId, cancellationToken);
        if (appointment is null)
        {
            return Result.Failure(AppointmentErrors.NotFound);
        }
        var result = appointment.Cancel(_dateTimeProvider.UtcNow);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
