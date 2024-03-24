using Dapper;
using doctorsAppointment.Application.Abstractions.Data;
using doctorsAppointment.Application.Abstractions.Messaging;
using doctorsAppointment.Application.Appointments.GetAppointment;
using doctorsAppointment.Domain.Abstractions;
using doctorsAppointment.Domain.Appointments;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Application.Appointments.ListAppointments;

internal sealed class ListAppointmentByDateQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<ListAppointmentByDateQuery, IReadOnlyList<AppointmentResponse>>
{
    private readonly ISqlConnectionFactory sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<IReadOnlyList<AppointmentResponse>>> Handle(ListAppointmentByDateQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                patient_id AS PatientId,
                user_id AS UserId,
                status AS Status,
                appointment_start AS AppointmentStart,
                appointment_end AS AppointmentEnd,
                description AS Description
            FROM appointments
            WHERE appointment_start >= @StartDate AND appointment_end <= @EndDate
            """;

        var appointments = await connection.QueryAsync<AppointmentResponse>(sql, new
        {
            request.StartDate,
            request.EndDate
        });
        if (appointments is null)
        {
            return Result.Failure<IReadOnlyList<AppointmentResponse>>(AppointmentErrors.NotFound);
        }
        return appointments.ToList();
    }
}