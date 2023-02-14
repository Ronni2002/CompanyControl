namespace ControlCompany.Entities.Companies;

public class Customer: BaseEntity
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public ICollection<Address>? Addresses { get; set; }

}