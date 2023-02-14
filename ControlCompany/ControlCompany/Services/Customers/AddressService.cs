using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Interfaces.Repositories.Customers;
using ControlCompany.Interfaces.Services.Customers;

namespace ControlCompany.Services.Customers;

public class AddressService: IAddressService
{
    private readonly IAddressRepository _repository;
    
    public AddressService(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddAsync(AddressDto create, CancellationToken cancellationToken = default)
    {
        await _repository.AddAsync(create, cancellationToken);
        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var address = await _repository.GetByIdAsync(id, cancellationToken);

        if (address is null)
            return 0;
        
        await _repository.DeleteAsync(address, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }
}