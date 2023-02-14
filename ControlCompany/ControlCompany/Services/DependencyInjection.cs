using ControlCompany.Interfaces.Services.Companies;
using ControlCompany.Interfaces.Services.Customers;
using ControlCompany.Services.Companies;
using ControlCompany.Services.Customers;

namespace ControlCompany.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        return service
            .AddTransient<IAddressService, AddressService>()
            .AddTransient<ICustomerService, CustomerService>()
            .AddTransient<ICompanyService, CompanyService>();
    }
}