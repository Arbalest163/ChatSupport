

namespace ChatSupport.Application.Users.Queries.GetUsersList;
public class UserDto : IMapWith<User>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy")]
    public DateTime Birthday { get; set; }
    public string Nickname { get; set; }
    public Role Role { get; set; }
    public UserChatsDto[] Chats { get; set; } = Array.Empty<UserChatsDto>();
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt
                  .MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt
                  .MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt
                  .MapFrom(src => src.LastName))
            .ForMember(dest => dest.MiddleName, opt => opt
                  .MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.Birthday, opt => opt
                  .MapFrom(src => src.Birthday))
            .ForMember(dest => dest.Nickname, opt => opt
                  .MapFrom(src => src.Nickname))
            .ForMember(dest => dest.Role, opt => opt
                  .MapFrom(src => src.Role))
            .ForMember(dest => dest.Chats, opt => opt
                  .MapFrom(src => src.Chats))
            ;
    }
}
