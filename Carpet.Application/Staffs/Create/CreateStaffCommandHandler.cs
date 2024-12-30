using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.Create;

public class CreateStaffCommandHandler : ICommandHandler<CreateStaffCommand, Guid>
{
    private readonly IStaffRepository _staffRepository;

    public CreateStaffCommandHandler(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }
    public async Task<Guid> Handle(CreateStaffCommand command, CancellationToken cancellationToken)
    {
        var staff = Staff.Create(command.Family, command.Mobile, command.Address,
                                   command.StaffType, command.ServiceProviderId);
        return _staffRepository.CreateAsync(staff);      
    }
}
