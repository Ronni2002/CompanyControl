namespace ControlCompany.DataTransferObject.Customers;

public class UpdateCustomer
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public Guid CompanyId { get; set; }
}