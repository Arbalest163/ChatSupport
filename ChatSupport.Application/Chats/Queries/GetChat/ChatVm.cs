namespace ChatSupport.Application.Chats.Queries.GetChat;
public class ChatVm : IMapWith<Chat>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public ICollection<MessageDto> Messages { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Chat, ChatVm>()
            .ForMember(dest => dest.Id, opt => opt
                  .MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt
                  .MapFrom(src => src.Title))
            .ForMember(dest => dest.Author, opt => opt
                  .MapFrom(src => src.User.Nickname))
            .ForMember(dest => dest.Messages, opt => opt
                  .MapFrom(src => src.Messages))
            ;
    }
}