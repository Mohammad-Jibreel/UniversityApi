using AutoMapper;
using UniversityApi.Dto;
using UniversityApi.Models;

namespace UniversityApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();
            CreateMap<UserQualification, UserQualificationDTO>().ReverseMap();
            CreateMap<University, UniversityDto>().ReverseMap();
            CreateMap<College, CollegeDto>().ReverseMap();
            CreateMap<Major, MajorDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();



        }
    }
}
