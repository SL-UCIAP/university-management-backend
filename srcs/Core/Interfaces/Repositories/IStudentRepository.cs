using university_management_service.srcs.Core.Entities;

namespace university_management_service.srcs.Core.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student student);
    Task<Student?> GetByNICAsync(string nic);
    Task<List<Student>> GetAllAsync();
    Task<Student> UpdateAsync(Student student);
    Task DeleteAsync(string nic);
    Task<bool> ExistsAsync(string nic);
}
