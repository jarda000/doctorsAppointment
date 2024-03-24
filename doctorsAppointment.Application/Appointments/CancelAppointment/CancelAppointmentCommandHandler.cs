using doctorsAppointment.Application.Abstractions.Clock;
using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments;

namespace doctorsAppointment.Application.Appointments.CancelAppointment;

internal sealed class CancelAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository, IDateTimeProvider dateTimeProvider) : ICommandHandler<CancelAppointmentCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

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
