using ControlCompany.DataTransferObject.Customers;

namespace ControlCompany.DataTransferObject.Companies;

public class GetCompany
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ShortName { get; set; }
    public int RNC { get; set; }
    public List<GetCustomer> Customers { get; set; }
}