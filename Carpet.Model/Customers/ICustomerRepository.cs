namespace Carpet.Domain.Customers
{
    public interface ICustomerRepository
    {
        Guid CreateAsync(Customer customer);
        Task<List<Customer>> GetListAsync(Guid serviceProvider, string? Family, string? code, string? mobile);
        Task<Customer?> GetByIdAsync(Guid id);

    }
}
