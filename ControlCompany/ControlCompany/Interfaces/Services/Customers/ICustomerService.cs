using ControlCompany.DataTransferObject.Customers;

namespace ControlCompany.Interfaces.Services.Customers;

public interface ICustomerService
{
    Task<List<GetCustomer>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<GetCustomer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<int> AddAsync(CreateCustomer create, CancellationToken cancellationToken = default);
    Task<int> UpdateAsync(UpdateCustomer update, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}