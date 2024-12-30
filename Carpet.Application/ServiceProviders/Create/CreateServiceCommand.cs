using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.ServiceProviders.Create;

public record CreateServiceCommand(string Name,
                            string? Code,
                            string Address,
                            string Tell,
                            string Mobile,
                            string? Description) :ICommand<Guid>;
