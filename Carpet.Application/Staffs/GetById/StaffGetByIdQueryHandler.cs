using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.GetById;

public class StaffGetByIdQueryHandler : IQueryHandler<StaffGetByIdQuery, Staff>
{
    private readonly IStaffRepository _staffRepository;

    public StaffGetByIdQueryHandler(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<Staff> Handle(StaffGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _staffRepository.GetByIdAsync(request.Id);
    }
}
