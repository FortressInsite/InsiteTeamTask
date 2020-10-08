using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Models;

namespace InsiteTeamTask.Configuration
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<AttendenceDto, AttendenceViewModel>().ReverseMap();
            CreateMap<TicketDto, TicketViewModel>().ReverseMap();
            CreateMap<MemberDto, MemberViewModel>().ReverseMap();
            CreateMap<SeasonDto, SeasonViewModel>();
            CreateMap<GameDto, GameViewModel>();
            CreateMap<ProductDto, ProductViewModel>();
        }
    }
}