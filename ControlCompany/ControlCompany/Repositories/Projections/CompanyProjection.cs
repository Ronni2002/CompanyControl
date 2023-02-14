using System.Linq.Expressions;
using ControlCompany.DataTransferObject.Companies;
using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Entities.Companies;

namespace ControlCompany.Repositories.Projections;

public static class CompanyProjection
{
    public static Expression<Func<Company, GetCompany>> Company { get; } = company => new GetCompany
    {
        Id = company.Id,
        Name = company.Name,
        ShortName = company.ShortName,
        RNC = company.RNC,
        Customers = company.Customers.Select(c => new GetCustomer
        {
            Id = c.Id,
            Name = c.Name,
            LastName = c.LastName,
            Age = c.Age,
            Addresses = c.Addresses!.Select(a => a.Value).ToList()
        }).ToList()
    };
}