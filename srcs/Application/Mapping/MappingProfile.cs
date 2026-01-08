using AutoMapper;
using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Application.Dto.Response;
using university_management_service.srcs.Core.Entities;

namespace university_management_service.srcs.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();
        CreateMap<Student, StudentResponseDto>();
        
        CreateMap<CertificateCreateDto, Certifications>();
        CreateMap<Certifications, CertificateResponseDto>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? src.Student.Name : ""));
    }
}
