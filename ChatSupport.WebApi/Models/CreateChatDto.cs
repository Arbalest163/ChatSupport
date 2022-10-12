using ChatSupport.Application.Chats.Commands.CreateChat;
using System.ComponentModel.DataAnnotations;

namespace ChatSupport.WebApi.Models;
public class CreateChatDto : IMapWith<CreateChatCommand>
{
    [Required]
    public string Title { get; set; }
    [Required]
    public int UserId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateChatDto, CreateChatCommand>()
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId))
            ;
    }
}
