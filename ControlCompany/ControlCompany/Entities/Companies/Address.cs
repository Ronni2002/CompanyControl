namespace ControlCompany.Entities.Companies;

public class Address: BaseEntity
{
    public string Value { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
}