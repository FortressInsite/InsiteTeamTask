using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Data.Configuration
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Season, SeasonDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}