namespace ChatSupport.Application.Chats.Queries.GetChats;
public class ChatDto : IMapWith<Chat>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Chat, ChatDto>()
            .ForMember(dest => dest.Id, opt => opt
                  .MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt
                  .MapFrom(src => src.Title))
            ;
    }
}
