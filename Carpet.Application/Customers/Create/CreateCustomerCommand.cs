using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.Customers.Create;

public record CreateCustomerCommand(string Family,
                                  string Mobile1,
                                  string Mobile2,
                                  string Address,
                                  string Code,
                                  Guid ServiceProviderId):ICommand<Guid>;
