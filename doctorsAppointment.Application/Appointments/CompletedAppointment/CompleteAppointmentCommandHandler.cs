using doctorsAppointment.Application.Abstractions.Clock;
using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Appointments.CompletedAppointment;

internal sealed class CompleteAppointmentCommandHandler(IDateTimeProvider dateTimeProvider, IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork) : ICommandHandler<CompleteAppointmentCommand>
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CompleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId, cancellationToken);
        if (appointment is null)
        {
            return Result.Failure(AppointmentErrors.NotFound);
        }
        var result = appointment.Complete(_dateTimeProvider.UtcNow);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
