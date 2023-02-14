using ControlCompany.DataTransferObject.Customers;

namespace ControlCompany.Interfaces.Services.Customers;

public interface IAddressService
{
    Task<int> AddAsync(AddressDto create, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}