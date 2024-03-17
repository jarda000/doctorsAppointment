using doctorsAppointment.Domain.Abstractions;
using MediatR;

namespace doctorsAppointment.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
