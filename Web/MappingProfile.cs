using AutoMapper;
using ForumApp.Entities.Models;
using ForumApp.Shared.DTO;

namespace ForumApp.Web;

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
        CreateMap<BlogForCreationDto, Blog>();
        CreateMap<BlogForUpdateDto, Blog>().ReverseMap();
        CreateMap<UserForUpdateDto, User>();
    }
}
