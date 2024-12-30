using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.Create;

public record CreateStaffCommand(string Family,
                                 string Mobile,
                                 string? Address,
                                 StaffType StaffType,
                                 Guid ServiceProviderId) :ICommand<Guid>;
