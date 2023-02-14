using System.ComponentModel.DataAnnotations;
using ControlCompany.Entities.Companies;

namespace ControlCompany.DataTransferObject.Companies;

public class CreateCompany
{
    [Required]
    public string Name { get; set; }
    public string ShortName { get; set; }
    [Required]
    public int RNC { get; set; }

    public static implicit operator Company(CreateCompany create)
    {
        return new Company
        {
            Id = Guid.NewGuid(),
            Name = create.Name,
            ShortName = create.ShortName,
            RNC = create.RNC
        };
    }
}