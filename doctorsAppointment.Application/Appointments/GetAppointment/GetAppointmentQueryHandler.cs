using Dapper;
using doctorsAppointment.Application.Abstractions.Data;
using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments;

namespace doctorsAppointment.Application.Appointments.GetAppointment;

internal sealed class GetAppointmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<GetAppointmentQuery, AppointmentResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<AppointmentResponse>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        const string sql = """
            SELECT
            id AS Id,
            patient_id AS PatientId,
            user_id AS UserId,
            status AS Status,
            appointment_start AS AppointmentStart,
            appointment_end AS AppointmentEnd,
            description AS Description
            """;

        var appointment = await connection.QuerySingleOrDefaultAsync<AppointmentResponse>(sql, new { request.AppointmentId });
        if (appointment is null)
        {
            return Result.Failure<AppointmentResponse>(AppointmentErrors.NotFound);
        }
        return appointment;
    }
}
