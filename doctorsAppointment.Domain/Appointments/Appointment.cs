using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments.Events;
using doctorsAppointment.Domain.Patients;

namespace doctorsAppointment.Domain.Appointments;

public sealed class Appointment : Entity
{
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? CanceledOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateRange ScheduledFor { get; private set; }
    public Patient Patient { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public Guid CreatorId { get; private set; }

    private Appointment(Guid Id, DateTime createdOnUtc, DateRange scheduledFor, Patient patient, AppointmentStatus status, Guid creatorId) : base(Id)
    {
        CreatedOnUtc = createdOnUtc;
        ScheduledFor = scheduledFor;
        Patient = patient;
        Status = status;
        CreatorId = creatorId;
    }
    private Appointment()
    {

    }
    public static Appointment Create(DateTime createdOnUtc, DateRange scheduledFor, Patient patient, Guid creatorId)
    {
        Appointment appointment = new(Guid.NewGuid(), createdOnUtc, scheduledFor, patient, AppointmentStatus.Pending, creatorId);

        appointment.RaiseDomainEvent(new AppointmentCreatedDomainEvent(appointment.Id));

        return appointment;
    }

    public Result Confirm(DateTime utcNow)
    {
        if (Status is not AppointmentStatus.Pending)
        {
            return Result.Failure(AppointmentErrors.NotPending);
        }
        Status = AppointmentStatus.Scheduled;
        ConfirmedOnUtc = utcNow;
        RaiseDomainEvent(new AppointmentConfirmedDomainEvent(Id));
        return Result.Success();
    }
    public Result Reject()
    {
        if (Status is not AppointmentStatus.Pending)
        {
            return Result.Failure(AppointmentErrors.NotPending);
        }
        Status = AppointmentStatus.Rejected;
        RaiseDomainEvent(new AppointmentRejectedDomainEvent(Id));
        return Result.Success();
    }
    public Result Complete(DateTime utcNow)
    {
        if (Status is not AppointmentStatus.Scheduled)
        {
            return Result.Failure(AppointmentErrors.NotScheduled);
        }
        if (utcNow.Date < ScheduledFor.End)
        {
            return Result.Failure(AppointmentErrors.NotFinished);
        }
        Status = AppointmentStatus.Completed;
        RaiseDomainEvent(new AppointmentCompletedDomainEvent(Id));
        return Result.Success();
    }
    public Result Cancel(DateTime utcNow)
    {
        if (Status is not AppointmentStatus.Pending)
        {
            return Result.Failure(AppointmentErrors.NotPending);
        }
        if (utcNow.Date >= ScheduledFor.Start)
        {
            return Result.Failure(AppointmentErrors.AlreadyInProgress);
        }
        Status = AppointmentStatus.Cancelled;
        CanceledOnUtc = utcNow;
        RaiseDomainEvent(new AppointmentCanceledDomainEvent(Id));
        return Result.Success();
    }
}
