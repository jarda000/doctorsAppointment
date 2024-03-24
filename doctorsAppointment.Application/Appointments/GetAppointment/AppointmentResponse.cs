namespace doctorsAppointment.Application.Appointments.GetAppointment;

public sealed class AppointmentResponse
{
    public Guid Id { get; init; }
    public Guid PatientId { get; init; }
    public Guid UserId { get; init; }
    public int Status { get; init; }
    public DateTime AppointmentStart { get; init; }
    public DateTime AppointmentEnd { get; init; }
    public string? Description { get; init; }
}
