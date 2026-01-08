namespace university_management_service.srcs.Application.Dto.Response;

public class CertificateResponseDto
{
    public long CertificationId { get; set; }
    public string StudentNIC { get; set; } = "";
    public string StudentName { get; set; } = "";
    public string CertificateName { get; set; } = "";
    public string Category { get; set; } = "";
    public string? Description { get; set; }
    public string CertificateHtmlContent { get; set; } = "";
    public DateTime IssuedDate { get; set; }
}
