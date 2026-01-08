using Microsoft.EntityFrameworkCore;
using university_management_service.srcs.Core.Entities;
using university_management_service.srcs.Core.Interfaces.Repositories;
using university_management_service.srcs.Insfastructure.Data;

namespace university_management_service.srcs.Insfastructure.Repositories;

public class CertificateRepository : ICertificateRepository
{
    private readonly AppDbContext _context;
    
    public CertificateRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Certifications> CreateAsync(Certifications certificate)
    {
        _context.Certifications.Add(certificate);
        await _context.SaveChangesAsync();
        return certificate;
    }
    
    public async Task<Certifications?> GetByIdAsync(long id)
    {
        return await _context.Certifications
            .Include(c => c.Student)
            .FirstOrDefaultAsync(c => c.CertificationId == id);
    }
    
    public async Task<List<Certifications>> GetByStudentNICAsync(string studentNIC)
    {
        return await _context.Certifications
            .Include(c => c.Student)
            .Where(c => c.StudentNIC == studentNIC)
            .ToListAsync();
    }
    
    public async Task<List<Certifications>> GetAllAsync()
    {
        return await _context.Certifications
            .Include(c => c.Student)
            .ToListAsync();
    }
}
