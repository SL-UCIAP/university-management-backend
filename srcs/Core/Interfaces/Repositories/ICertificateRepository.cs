using university_management_service.srcs.Core.Entities;

namespace university_management_service.srcs.Core.Interfaces.Repositories;

public interface ICertificateRepository
{
    Task<Certifications> CreateAsync(Certifications certificate);
    Task<Certifications?> GetByIdAsync(long id);
    Task<List<Certifications>> GetByStudentNICAsync(string studentNIC);
    Task<List<Certifications>> GetAllAsync();
}
