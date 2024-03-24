using doctorsAppointment.Domain.Abstractions;

namespace doctorsAppointment.Domain.Appointments;

public static class AppointmentErrors
{
    public static Error NotFound = new("Appointment.NotFound", "Appointment with the specified identifier was not found");
    public static Error Overlap = new("Appointment.Overlap", "The appointment overlaps with another appointment");
    public static Error NotConfirmed = new("Appointment.NotConfirmed", "The appointment is not confirmed");
    public static Error NotScheduled = new("Appointment.NotScheduled", "The appointment is not scheduled");
    public static Error NotPending = new("Appointment.NotPending", "The appointment is not pending");
    public static Error NotFinished = new("Appointment.NotFinished", "The appointment is not finished");
    public static Error AlreadyInProgress = new("Appointment.AlreadyInProgress", "The appointment is already in progress");
}
