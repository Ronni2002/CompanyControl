using ControlCompany.DataTransferObject.Customers;
using ControlCompany.Interfaces.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace ControlCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController: ControllerBase
{
    private readonly ICustomerService _service;
    
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return Ok(await _service.GetAllAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var company = await _service.GetByIdAsync(id, cancellationToken);

            if (company is null)
                return NotFound();

            return Ok(company);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCustomer create, CancellationToken cancellationToken = default)
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
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateCustomer update, CancellationToken cancellationToken = default)
    {
        try
        {
            await _service.UpdateAsync(update, cancellationToken);
            return Ok();
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