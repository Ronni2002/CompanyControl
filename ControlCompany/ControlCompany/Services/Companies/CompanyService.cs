using ControlCompany.DataTransferObject.Companies;
using ControlCompany.Interfaces.Repositories.Companies;
using ControlCompany.Interfaces.Repositories.Customers;
using ControlCompany.Interfaces.Services.Companies;

namespace ControlCompany.Services.Companies;

public class CompanyService: ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly ICustomerRepository _customerRepository;
    
    public CompanyService(ICompanyRepository repository, ICustomerRepository customerRepository)
    {
        _repository = repository;
        _customerRepository = customerRepository;
    }

    public Task<List<GetCompany>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<GetCompany?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repository.GetByIdCustomAsync(id, cancellationToken);
    }

    public Task<int> AddAsync(CreateCompany create, CancellationToken cancellationToken = default)
    {
        _repository.AddAsync(create, cancellationToken);
        return _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(UpdateCompany update, CancellationToken cancellationToken = default)
    {
        var company = await _repository.GetByIdAsync(update.Id, cancellationToken);

        if (company is null)
            return 0;
        
        company.Name = update.Name;
        company.ShortName = update.ShortName;
        company.RNC = update.RNC;

        await _repository.UpdateAsync(company, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var company = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (company is null)
            return 0;
        
        var customers = await _customerRepository.GetByCompanyId(id, cancellationToken);

        if (customers.Count > 0)
        {
            foreach (var customer in customers)
            {
                await _customerRepository.DeleteAsync(customer, cancellationToken);
            }
        }

        await _repository.DeleteAsync(company, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }
}