using Carpet.DBContext;
using Carpet.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Carpet.Infrastructure.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Guid CreateAsync(Customer customer)
        {
            _context.AddAsync(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Custumers.FindAsync(id);
        }

        public async Task<List<Customer>> GetListAsync(Guid serviceProvider, string? Family, string? code, string? mobile)
        {
            var customers = _context.Custumers.Where(x => x.ServiceProviderId == serviceProvider).AsNoTracking();

            if (code != null)
            {
                customers = customers.Where(x => x.Code == code);
            }
            if (Family != null)
            {
                customers = customers.Where(x => x.Family.Contains(Family));
            }
            if (mobile != null)
            {
                customers = customers.Where(x => x.MobileNo1 == mobile || x.MobileNo2 == mobile);
            }
            return await customers.ToListAsync();
        }
    }
}
