namespace ChatSupport.Application.Chats.Queries.GetChat;
public class GetChatQuery : IRequest<ChatVm>
{
    public int ChatId { get; set; }
    public int UserId { get; set; }
}
