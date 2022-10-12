namespace ChatSupport.Application.Chats.Queries.GetChat;
public class MessageDto : IMapWith<Message>
{
    public string Author { get; set; }
    public DateTimeOffset DateSent { get; set; }
    public string Message { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Message, MessageDto>()
            .ForMember(dest => dest.Author, opt => opt
                  .MapFrom(src => src.User.Nickname))
            .ForMember(dest => dest.DateSent, opt => opt
                  .MapFrom(src => src.DateSendMessage))
            .ForMember(dest => dest.Message, opt => opt
                  .MapFrom(src => src.Text))
            ;
    }
}
