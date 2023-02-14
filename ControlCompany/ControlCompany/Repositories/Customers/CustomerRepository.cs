using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Entities.Companies;
using ControlCompany.Interfaces.Repositories.Customers;
using ControlCompany.Repositories.Context;
using ControlCompany.Repositories.Projections;
using Microsoft.EntityFrameworkCore;

namespace ControlCompany.Repositories.Customers;

public class CustomerRepository: Repository<Customer>, ICustomerRepository
{
    private readonly ControlDbContext _context;
    
    public CustomerRepository(ControlDbContext context): base(context)
    {
        _context = context;
    }

    public Task<List<GetCustomer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _context.Customers
            .AsNoTracking()
            .Select(CustomerProjection.Customer)
            .ToListAsync(cancellationToken);
    }

    public Task<List<Customer>> GetByCompanyId(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Customers
            .Where(c => c.CompanyId == id)
            .ToListAsync(cancellationToken);
    }

    public Task<GetCustomer?> GetByIdCostumeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Customers
            .AsNoTracking()
            .Select(CustomerProjection.Customer)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}