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

        CreateMap<Blog, CommentDto>().ForMember(c => c.DateAdded,
            opt => opt.MapFrom(src => src.DateAdded.ToString()));

        CreateMap<UserForCreationDto, User>();
        CreateMap<CommentForCreationDto, Blog>();
        CreateMap<PostForUpdateDto, Blog>().ReverseMap();
        CreateMap<UserForUpdateDto, User>();
        CreateMap<UserForRegistrationDto, User>()
            .ForMember(n => n.Name, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(n => n.Surname, opt => opt.MapFrom(src => src.LastName));

        CreateMap<PostForCreationDto, Blog>();
    }
}
