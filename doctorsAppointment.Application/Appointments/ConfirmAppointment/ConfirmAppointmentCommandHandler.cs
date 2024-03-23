using doctorsAppointment.Application.Abstractions.Clock;
using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Appointments.ConfirmAppointment;

internal sealed class ConfirmAppointmentCommandHandler(IDateTimeProvider dateTimeProvider, IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork) : ICommandHandler<ConfirmAppointmentCommand>
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(ConfirmAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId, cancellationToken);
        if (appointment is null)
        {
            return Result.Failure(AppointmentErrors.NotFound);
        }
        var result = appointment.Confirm(_dateTimeProvider.UtcNow);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
