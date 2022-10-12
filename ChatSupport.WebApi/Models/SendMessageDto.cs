using ChatSupport.Application.Chats.Commands.SendMessage;

namespace ChatSupport.WebApi.Models;
public class SendMessageDto : IMapWith<SendMessageCommand>
{
    public int UserId { get; set; }
    public string Message { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SendMessageDto, SendMessageCommand>()
            .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Message,
                opt => opt.MapFrom(src => src.Message))
            ;
    }
}
