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
                opt => opt.MapFrom(x => x.DateRegistration.ToString()));
        }
    }
}
