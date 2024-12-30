using AutoMapper;
using Carpet.Application.Customers.GetList;
using Carpet.Application.Orders.GetList;
using Carpet.Application.ServiceProviders.GetList;
using Carpet.Application.Staffs.GetList;
using Carpet.Domain.Customers;
using Carpet.Domain.Orders;
using Carpet.Domain.ServiceProviders;
using Carpet.Domain.Staffs;

namespace Carpet.Application.Common.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<ServiceCarpet, ServiceDto>();
        CreateMap<Staff, StaffDto>();
        CreateMap<Order, OrderDto>();
    }
}
