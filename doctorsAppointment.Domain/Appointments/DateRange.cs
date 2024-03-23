namespace doctorsAppointment.Domain.Appointments;

public record DateRange
{
    private DateRange()
    {
    }

    public DateTime Start { get; init; }

    public DateTime End { get; init; }


    public static DateRange Create(DateTime start, DateTime end)
    {
        if (start > end)
        {
            throw new ApplicationException("End time precedes start time");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}
