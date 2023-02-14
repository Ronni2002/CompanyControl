using ControlCompany.Entities.Companies;

namespace ControlCompany.DataTransferObject.Customers;

public class GetCustomer
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string LastName { get; set; } 
    public int Age { get; set; }
    public List<string> Addresses { get; set; }
}