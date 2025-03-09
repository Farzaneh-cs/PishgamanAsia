using AutoMapper;
using Carpet.Application.Staffs.GetList;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Common.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Staff, StaffDto>();
    }
}
