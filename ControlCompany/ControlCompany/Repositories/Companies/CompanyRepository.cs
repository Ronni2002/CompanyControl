using ControlCompany.DataTransferObject.Companies;
using ControlCompany.Entities.Companies;
using ControlCompany.Interfaces.Repositories.Companies;
using ControlCompany.Repositories.Context;
using ControlCompany.Repositories.Projections;
using Microsoft.EntityFrameworkCore;

namespace ControlCompany.Repositories.Companies;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private readonly ControlDbContext _context;

    public CompanyRepository(ControlDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<GetCompany>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _context.Companies
            .AsNoTracking()
            .Select(CompanyProjection.Company)
            .ToListAsync(cancellationToken);
    }

    public Task<GetCompany?> GetByIdCustomAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Companies
            .AsNoTracking()
            .Select(CompanyProjection.Company)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}