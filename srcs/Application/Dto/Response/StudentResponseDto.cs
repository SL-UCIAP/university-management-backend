namespace university_management_service.srcs.Application.Dto.Response;

public class StudentResponseDto
{
    public string NIC { get; set; } = "";
    public string Name { get; set; } = "";
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public DateTime RegisteredDate { get; set; }
}
