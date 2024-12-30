using MediatR;

namespace Carpet.Application.Abstraction.Messaging;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}
