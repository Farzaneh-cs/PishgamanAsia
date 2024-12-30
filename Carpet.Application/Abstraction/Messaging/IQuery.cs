using MediatR;

namespace Carpet.Application.Abstraction.Messaging;
public interface IQuery<TResponse> : IRequest<TResponse>
{
}
