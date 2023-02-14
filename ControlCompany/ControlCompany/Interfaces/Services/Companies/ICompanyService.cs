using ControlCompany.DataTransferObject.Companies;

namespace ControlCompany.Interfaces.Services.Companies;

public interface ICompanyService
{
    Task<List<GetCompany>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<GetCompany?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> AddAsync(CreateCompany create, CancellationToken cancellationToken = default);
    Task<int> UpdateAsync(UpdateCompany update, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}