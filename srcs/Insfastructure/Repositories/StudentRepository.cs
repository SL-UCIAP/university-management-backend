using Microsoft.EntityFrameworkCore;
using university_management_service.srcs.Core.Entities;
using university_management_service.srcs.Core.Interfaces.Repositories;
using university_management_service.srcs.Insfastructure.Data;

namespace university_management_service.srcs.Insfastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;
    
    public StudentRepository(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<Student> CreateAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }
    
    public async Task<Student?> GetByNICAsync(string nic)
    {
        return await _context.Students
            .Include(s => s.Certifications)
            .Include(s => s.Results)
            .FirstOrDefaultAsync(s => s.NIC == nic);
    }
    
    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }
    
    public async Task<Student> UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }
    
    public async Task DeleteAsync(string nic)
    {
        var student = await GetByNICAsync(nic);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<bool> ExistsAsync(string nic)
    {
        return await _context.Students.AnyAsync(s => s.NIC == nic);
    }
}
