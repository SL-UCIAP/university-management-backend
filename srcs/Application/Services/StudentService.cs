using AutoMapper;
using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Application.Dto.Response;
using university_management_service.srcs.Core.Entities;
using university_management_service.srcs.Core.Interfaces.Repositories;
using university_management_service.srcs.Core.Interfaces.Services;

namespace university_management_service.srcs.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;
    
    public StudentService(IStudentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StudentResponseDto> CreateAsync(StudentCreateDto studentCreateDto)
    {
        if (await _repository.ExistsAsync(studentCreateDto.NIC))
        {
            throw new InvalidOperationException($"Student with NIC {studentCreateDto.NIC} already exists.");
        }
        
        var studentEntity = _mapper.Map<Student>(studentCreateDto);
        var student = await _repository.CreateAsync(studentEntity);
        return _mapper.Map<StudentResponseDto>(student);
    }

    public async Task<StudentResponseDto?> GetByNICAsync(string nic)
    {
        var student = await _repository.GetByNICAsync(nic);
        return student == null ? null : _mapper.Map<StudentResponseDto>(student);
    }

    public async Task<List<StudentResponseDto>> GetAllStudentsAsync()
    {
        var students = await _repository.GetAllAsync();
        return _mapper.Map<List<StudentResponseDto>>(students);
    }

    public async Task<StudentResponseDto> UpdateAsync(string nic, StudentUpdateDto studentUpdateDto)
    {
        var existingStudent = await _repository.GetByNICAsync(nic);
        if (existingStudent == null)
        {
            throw new KeyNotFoundException($"Student with NIC {nic} not found.");
        }
        
        _mapper.Map(studentUpdateDto, existingStudent);
        var updatedStudent = await _repository.UpdateAsync(existingStudent);
        return _mapper.Map<StudentResponseDto>(updatedStudent);
    }

    public async Task<bool> DeleteAsync(string nic)
    {
        if (!await _repository.ExistsAsync(nic))
        {
            return false;
        }
        
        await _repository.DeleteAsync(nic);
        return true;
    }
}
