using ControlCompany.Entities.Companies;
using ControlCompany.Interfaces.Repositories.Customers;
using ControlCompany.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ControlCompany.Repositories.Customers;

public class AddressRepository: Repository<Address>, IAddressRepository
{
    private readonly ControlDbContext _context;
    public AddressRepository(ControlDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<Address>> GetByCustomerId(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Addresses.Where(a => a.CustomerId == id).ToListAsync(cancellationToken);
    }
}