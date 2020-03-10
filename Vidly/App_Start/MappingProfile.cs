using AutoMapper;
using UDemyVidly.Dtos;
using UDemyVidly.Models;

namespace UDemyVidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}