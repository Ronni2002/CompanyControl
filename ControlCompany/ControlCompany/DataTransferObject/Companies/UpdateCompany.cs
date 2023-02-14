namespace ControlCompany.DataTransferObject.Companies;

public class UpdateCompany
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public int RNC { get; set; }
}