using doctorsAppointment.Domain.Abstractions;
using MediatR;

namespace doctorsAppointment.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;