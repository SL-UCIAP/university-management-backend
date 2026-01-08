using Microsoft.AspNetCore.Mvc;
using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Core.Interfaces.Services;

namespace university_management_service.srcs.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCertificate([FromBody] CertificateCreateDto certificateDto)
    {
        try
        {
            var certificate = await _certificateService.CreateCertificateAsync(certificateDto);
            return CreatedAtAction(nameof(GetCertificateById), new { id = certificate.CertificationId }, certificate);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (FileNotFoundException ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCertificateById(long id)
    {
        var certificate = await _certificateService.GetByIdAsync(id);
        if (certificate == null)
        {
            return NotFound(new { message = $"Certificate with ID {id} not found." });
        }
        return Ok(certificate);
    }

    [HttpGet("student/{nic}")]
    public async Task<IActionResult> GetCertificatesByStudentNIC(string nic)
    {
        var certificates = await _certificateService.GetByStudentNICAsync(nic);
        return Ok(certificates);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCertificates()
    {
        var certificates = await _certificateService.GetAllAsync();
        return Ok(certificates);
    }
    
    
}
