using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Interfaces.Repositories.Customers;
using ControlCompany.Interfaces.Services.Customers;

namespace ControlCompany.Services.Customers;

public class CustomerService: ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IAddressRepository _addressRepository;
    
    public CustomerService(ICustomerRepository repository, IAddressRepository addressRepository)
    {
        _repository = repository;
        _addressRepository = addressRepository;
    }

    public Task<List<GetCustomer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
    
    public Task<GetCustomer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repository.GetByIdCostumeAsync(id, cancellationToken);
    }
    
    public async Task<int> AddAsync(CreateCustomer create, CancellationToken cancellationToken = default)
    {
        create.Id = Guid.NewGuid();
        await _repository.AddAsync(create, cancellationToken);
        await _addressRepository.AddRangeAsync(create, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(UpdateCustomer update, CancellationToken cancellationToken = default)
    {
        var customer = await _repository.GetByIdAsync(update.Id, cancellationToken);

        if (customer is null)
            return 0;
        
        customer.Name = update.Name;
        customer.LastName = update.LastName;
        customer.Age = update.Age;
        customer.CompanyId = update.CompanyId;

        await _repository.UpdateAsync(customer, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _repository.GetByIdAsync(id, cancellationToken);

        if (customer is null)
            return 0;
        
        var addresses = await _addressRepository.GetByCustomerId(id, cancellationToken);

        if (addresses.Count > 0)
        {
            foreach (var address in addresses)
            {
                await _addressRepository.DeleteAsync(address, cancellationToken);
            }
        }
        
        await _repository.DeleteAsync(customer, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }
}