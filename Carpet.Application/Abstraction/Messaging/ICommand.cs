using MediatR;

namespace Carpet.Application.Abstraction.Messaging;

public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand;

public interface IBaseCommand;
