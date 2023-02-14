using ControlCompany.Entities.Companies;

namespace ControlCompany.Interfaces.Repositories.Customers;

public interface IAddressRepository : IRepository<Address>
{
    Task<List<Address>> GetByCustomerId(Guid id, CancellationToken cancellationToken = default);
}