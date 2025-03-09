using AutoMapper;
using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.GetList;

public class StaffGetListQueryHandler : IQueryHandler<StaffGetListQuery, List<StaffDto>>
{
    private readonly IStaffRepository _staffRepository;
    private readonly IMapper _mapper;

    public StaffGetListQueryHandler(IStaffRepository staffRepository,
                                       IMapper mapper)
    {
        _staffRepository = staffRepository;
        _mapper = mapper;
    }
    public async Task<List<StaffDto>> Handle(StaffGetListQuery request, CancellationToken cancellationToken)
    {
        var staffs = await _staffRepository.GetListAsync(request.Family,
                                                         request.NationalCode,
                                                         request.number,
                                                         request.pagesize);

        return staffs.Select(x => new StaffDto
        {
            Id = x.Id,
            Family = x.FirstName + " " + x.LastName,
            Mobile = x.MobileNumber,
            NationalCode = x.NationalCode
        }).ToList();
    }
}
