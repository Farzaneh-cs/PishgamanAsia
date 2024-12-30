using Carpet.Application.Abstraction.Messaging;
namespace Carpet.Application.Customers.GetList
{
    public record GetListCustomerQuery(Guid serviceProvider, 
                                       string? Family,
                                       string? code, 
                                       string? mobile) :IQuery<List<CustomerDto>>;
}
