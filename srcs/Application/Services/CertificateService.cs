using AutoMapper;
using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Application.Dto.Response;
using university_management_service.srcs.Core.Entities;
using university_management_service.srcs.Core.Interfaces.Repositories;
using university_management_service.srcs.Core.Interfaces.Services;
using university_management_service.srcs.Utils;

namespace university_management_service.srcs.Application.Services;

public class CertificateService : ICertificateService
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    
    public CertificateService(
        ICertificateRepository certificateRepository,
        IStudentRepository studentRepository,
        IMapper mapper)
    {
        _certificateRepository = certificateRepository;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<CertificateResponseDto> CreateCertificateAsync(CertificateCreateDto certificateDto)
    {
        // Fetch student by NIC
        var student = await _studentRepository.GetByNICAsync(certificateDto.StudentNIC);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with NIC {certificateDto.StudentNIC} not found.");
        }
        
        // Generate HTML by injecting student details into template
        var htmlContent = GenerateCertificateHtml(
            student.Name,
            certificateDto.Description ?? certificateDto.CertificateName,
            DateTime.UtcNow,
            certificateDto.Category
        );
        
        // Create certificate entity
        var certificate = new Certifications
        {
            StudentNIC = certificateDto.StudentNIC,
            CertificateName = certificateDto.CertificateName,
            Category = certificateDto.Category,
            Description = certificateDto.Description,
            CertificateHtmlContent = htmlContent,
            IssuedDate = DateTime.UtcNow
        };
        
        // Save to database
        var createdCertificate = await _certificateRepository.CreateAsync(certificate);
        createdCertificate.Student = student;
        
        return _mapper.Map<CertificateResponseDto>(createdCertificate);
    }
    
    public async Task<CertificateResponseDto?> GetByIdAsync(long id)
    {
        var certificate = await _certificateRepository.GetByIdAsync(id);
        return certificate == null ? null : _mapper.Map<CertificateResponseDto>(certificate);
    }
    
    public async Task<List<CertificateResponseDto>> GetByStudentNICAsync(string studentNIC)
    {
        var certificates = await _certificateRepository.GetByStudentNICAsync(studentNIC);
        return _mapper.Map<List<CertificateResponseDto>>(certificates);
    }
    
    public async Task<List<CertificateResponseDto>> GetAllAsync()
    {
        var certificates = await _certificateRepository.GetAllAsync();
        return _mapper.Map<List<CertificateResponseDto>>(certificates);
    }
    
    public async Task<string> GetCertificateHtmlAsync(long certificateId)
    {
        var certificate = await _certificateRepository.GetByIdAsync(certificateId);
        if (certificate == null)
        {
            throw new KeyNotFoundException($"Certificate with ID {certificateId} not found.");
        }
        
        return certificate.CertificateHtmlContent;
    }
    
    public async Task<string> ExportCertificateToFileAsync(long certificateId, string outputDirectory)
    {
        var certificate = await _certificateRepository.GetByIdAsync(certificateId);
        if (certificate == null)
        {
            throw new KeyNotFoundException($"Certificate with ID {certificateId} not found.");
        }
        
        // Create output directory if it doesn't exist
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }
        
        // Generate filename: StudentNIC_CertificateName_Date.html
        var fileName = $"{certificate.StudentNIC}_{certificate.CertificateName.Replace(" ", "_")}_{certificate.IssuedDate:yyyyMMdd}.html";
        var filePath = Path.Combine(outputDirectory, fileName);
        
        // Write HTML content to file
        await File.WriteAllTextAsync(filePath, certificate.CertificateHtmlContent);
        
        return filePath;
    }
    
   
    private string GenerateCertificateHtml(string studentName, string description, DateTime issueDate, string category)
    {
        // Get template based on category
        string template;
        if (category.ToLower().Contains("honor"))
        {
            template = CertificateTemplates.GetTemplate("honors");
        }
        else
        {
            template = CertificateTemplates.GetTemplate("default");
        }
        
        // Inject student details into template placeholders
        var htmlContent = template
            .Replace("{{STUDENT_NAME}}", studentName)
            .Replace("{{CERTIFICATE_DESCRIPTION}}", description)
            .Replace("{{ISSUE_DATE}}", issueDate.ToString("MMMM dd, yyyy"));
        
        return htmlContent;
    }
}
