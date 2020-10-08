using AutoMapper;
using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Logic.Configuration
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<MemberDto, AttendenceDto>();
        }
    }
}