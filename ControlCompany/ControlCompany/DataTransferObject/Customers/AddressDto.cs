using ControlCompany.Entities.Companies;

namespace ControlCompany.DataTransferObject.Customers;

public class AddressDto
{
    public string Value { get; set; }
    public Guid CustomerId { get; set; }

    public static implicit operator Address(AddressDto create)
    {
        return new Address
        {
            Id = Guid.NewGuid(),
            Value = create.Value,
            CustomerId = create.CustomerId
        };
    }
}