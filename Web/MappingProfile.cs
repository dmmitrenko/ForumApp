using AutoMapper;
using ForumApp.Entities.Models;
using ForumApp.Shared.DTO;

namespace ForumApp.Web;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, PostDto>();
        CreateMap<PostForCreationDto, Post>();
        CreateMap<PostForUpdateDto, Post>();

        CreateMap<Comment, CommentDto>()
            .ForMember(c => c.DateAdded, opt => opt.MapFrom(src => src.DateAdded.ToString()))
            .ForMember(c => c.LastChange, opt => opt.MapFrom(src => src.LastChange.ToString()));
        CreateMap<CommentForCreationDto, Comment>();
        CreateMap<CommentForUpdateDto, Comment>().ReverseMap();

        CreateMap<UserForRegistrationDto, User>()
            .ForMember(n => n.Name, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(n => n.Surname, opt => opt.MapFrom(src => src.LastName));
    }
}
