using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Entities.Companies;

namespace ControlCompany.Interfaces.Repositories.Customers;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<List<Customer>> GetByCompanyId(Guid id, CancellationToken cancellationToken = default);
    Task<GetCustomer?> GetByIdCostumeAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<GetCustomer>> GetAllAsync(CancellationToken cancellationToken = default);
}