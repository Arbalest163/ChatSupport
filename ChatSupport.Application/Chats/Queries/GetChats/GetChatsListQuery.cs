namespace ChatSupport.Application.Chats.Queries.GetChats;
public class GetChatsListQuery : IRequest<ChatsListVm> 
{
    public int? UserId { get; set; }
}
