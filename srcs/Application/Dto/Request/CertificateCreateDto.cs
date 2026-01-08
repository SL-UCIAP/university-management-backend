namespace university_management_service.srcs.Application.Dto.Request;

public class CertificateCreateDto
{
    public string StudentNIC { get; set; } = "";
    public string CertificateName { get; set; } = "";
    public string Category { get; set; } = "";
    public string? Description { get; set; }
}
