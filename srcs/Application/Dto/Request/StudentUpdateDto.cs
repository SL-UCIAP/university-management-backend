namespace university_management_service.srcs.Application.Dto.Request;

public class StudentUpdateDto
{
    public string Name { get; set; } = "";
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
