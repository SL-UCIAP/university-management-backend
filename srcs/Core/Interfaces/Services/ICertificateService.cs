using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Application.Dto.Response;

namespace university_management_service.srcs.Core.Interfaces.Services;

public interface ICertificateService
{
    Task<CertificateResponseDto> CreateCertificateAsync(CertificateCreateDto certificateDto);
    Task<CertificateResponseDto?> GetByIdAsync(long id);
    Task<List<CertificateResponseDto>> GetByStudentNICAsync(string studentNIC);
    Task<List<CertificateResponseDto>> GetAllAsync();
    Task<string> GetCertificateHtmlAsync(long certificateId);
    Task<string> ExportCertificateToFileAsync(long certificateId, string outputDirectory);
}
