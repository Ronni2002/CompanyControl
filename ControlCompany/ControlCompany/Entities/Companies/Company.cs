namespace ControlCompany.Entities.Companies;

public class Company: BaseEntity
{
    public string Name { get; set; } = null!;
    public string? ShortName { get; set; }
    public int RNC { get; set; }
    public ICollection<Customer> Customers { get; set; } = null!;
}