using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Application.Dto.Response;

namespace university_management_service.srcs.Core.Interfaces.Services;

public interface IStudentService
{
    Task<StudentResponseDto> CreateAsync(StudentCreateDto studentCreateDto);
    Task<StudentResponseDto?> GetByNICAsync(string nic);
    Task<List<StudentResponseDto>> GetAllStudentsAsync();
    Task<StudentResponseDto> UpdateAsync(string nic, StudentUpdateDto studentUpdateDto);
    Task<bool> DeleteAsync(string nic);
}
