using ControlCompany.DataTransferObject.Companies;
using ControlCompany.Interfaces.Services.Companies;
using Microsoft.AspNetCore.Mvc;

namespace ControlCompany.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController: ControllerBase
{
    private readonly ICompanyService _service;
    
    public CompanyController(ICompanyService service)
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
    public async Task<IActionResult> AddAsync(CreateCompany create, CancellationToken cancellationToken = default)
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
    public async Task<IActionResult> UpdateAsync(UpdateCompany update, CancellationToken cancellationToken = default)
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