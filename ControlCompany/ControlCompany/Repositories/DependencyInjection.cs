using ControlCompany.Interfaces.Repositories.Companies;
using ControlCompany.Interfaces.Repositories.Customers;
using ControlCompany.Repositories.Companies;
using ControlCompany.Repositories.Customers;

namespace ControlCompany.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        return service
            .AddTransient<IAddressRepository, AddressRepository>()
            .AddTransient<ICustomerRepository, CustomerRepository>()
            .AddTransient<ICompanyRepository, CompanyRepository>();
    }
}