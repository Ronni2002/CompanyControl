using ControlCompany.Entities.Companies;

namespace ControlCompany.DataTransferObject.Customers;

public class CreateCustomer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Guid CompanyId { get; set; }
    public List<string> Addresses { get; set; }

    public static implicit operator Customer(CreateCustomer create)
    {
        return new Customer
        {
            Id = create.Id,
            Name = create.Name,
            LastName = create.LastName,
            Age = create.Age,
            CompanyId = create.CompanyId
        };
    }

    public static implicit operator List<Address>(CreateCustomer create)
    {
        return create.Addresses.Select(c => new Address
        {
            Id = Guid.NewGuid(), 
            CustomerId = create.Id, 
            Value = c 
        }).ToList();
    }
}