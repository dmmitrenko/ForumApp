using AutoMapper;
using Entities.Models;
using Shared.DTO;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ForMember(c => c.DateRegistration,
                opt => opt.MapFrom(x => x.DateRegistration.ToString()))
                .ForMember(n => n.FullName, 
                opt => opt.MapFrom(x => x.Name + " " + x.Surname));

            CreateMap<Blog, BlogDto>().ForMember(c => c.DateAdded,
                opt => opt.MapFrom(src => src.DateAdded.ToString()));

            CreateMap<UserForCreationDto, User>();
        }
    }
}
