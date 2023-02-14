using System.Linq.Expressions;
using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Entities.Companies;

namespace ControlCompany.Repositories.Projections;

public static class CustomerProjection
{
    public static Expression<Func<Customer, GetCustomer>> Customer { get; } = customer => new GetCustomer
    {
        Id = customer.Id,
        Name = customer.Name,
        LastName = customer.LastName,
        Age = customer.Age,
        Addresses = customer.Addresses!.Select(a => a.Value).ToList()
    };
}