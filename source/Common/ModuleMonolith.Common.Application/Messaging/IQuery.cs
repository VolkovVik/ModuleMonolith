using MediatR;
using ModuleMonolith.Common.Domain;

namespace ModuleMonolith.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
