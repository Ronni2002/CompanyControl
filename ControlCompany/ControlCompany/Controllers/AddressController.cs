using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Interfaces.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace ControlCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController: ControllerBase
{
    private readonly IAddressService _service;
    
    public AddressController(IAddressService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(AddressDto create, CancellationToken cancellationToken = default)
    {
        try
        {
            await _service.AddAsync(create, cancellationToken);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            await _service.DeleteAsync(id, cancellationToken);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}