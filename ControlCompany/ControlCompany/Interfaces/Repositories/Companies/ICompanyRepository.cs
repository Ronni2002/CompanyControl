using ControlCompany.DataTransferObject.Companies;
using ControlCompany.Entities.Companies;

namespace ControlCompany.Interfaces.Repositories.Companies;

public interface ICompanyRepository : IRepository<Company>
{
    Task<GetCompany?> GetByIdCustomAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<GetCompany>> GetAllAsync(CancellationToken cancellationToken = default);
}